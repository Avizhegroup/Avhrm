using System.Net.Http.Headers;
using System.Net;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;
using Microsoft.JSInterop;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components;
using Avhrm.Application.Client.Features;
using Microsoft.Extensions.Configuration;

namespace Avhrm.Infrastructure.Client;
public class ApiHandler(IJSRuntime jsRuntime
    , ILogger<ApiHandler> logger
    , NavigationManager navigationManager
    , IConfiguration configuration) : HttpClientHandler
{
    private string baseUrl;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        string? token;

#if BlazorServer
        token = await jsRuntime.InvokeAsync<string?>("window.localStorage.getItem", "jwt");
#else
        token = Preferences.Get("access_token", null);
#endif

        if (token.HasValue())
        {
            request.Headers.Authorization = new("Bearer", token);
        }
        else
        {
            request.Headers.Remove("Authorization");
        }

        var response = await base.SendAsync(request, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
#if BlazorServer
                await jsRuntime.InvokeVoidAsync("window.localStorage.removeItem", "jwt");
#else
                    Preferences.Remove("access_token");
#endif
                navigationManager.NavigateTo("/account/login", true);
            }
        }
        return response;
    }

    public async Task<ApiResponse<T>> SendJsonAsync<T>(HttpMethod method
        , string uri
        , object data = null)
    {
        if (baseUrl.HasNoValue())
        {
            SetUri();
        }

        JsonSerializerOptions option = new()
        {
            PropertyNameCaseInsensitive = true,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };

        var passDataJsonString = JsonSerializer.Serialize(data);
        var buffer = Encoding.UTF8.GetBytes(passDataJsonString);
        var byteContent = new ByteArrayContent(buffer);
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        HttpRequestMessage request = new(method, baseUrl + uri);

        request.Content = byteContent;

        var resultStream = await SendAsync(request, new CancellationToken());

        Stream httpStream = await resultStream.Content.ReadAsStreamAsync();

        var result = await JsonSerializer.DeserializeAsync<ApiResponse<T>>(httpStream, option);

        return result;
    }

    private void SetUri()
    {
        baseUrl = configuration["Api:Ip"];
    }
} 
