using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;
using Microsoft.JSInterop;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components;

namespace Avhrm.Infrastructure;
public class ApiHandler(IJSRuntime jsRuntime
    , ILogger<ApiHandler> logger) : HttpClientHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request
        , NavigationManager NavigationManager
        , CancellationToken cancellationToken)
    {
        var storageResult = await jsRuntime.InvokeAsync<string>("window.localStorage.getItem", "jwt");

        if (storageResult.HasValue())
        {
            request.Headers.Authorization = new("Bearer", storageResult);
        }
        else
        {
            request.Headers.Remove("Authorization");
        }

        var response = await base.SendAsync(request, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            if (response.Content.Headers.ContentType?.MediaType == "application/json")
            {
                var errorResult = await response.Content.ReadFromJsonAsync<ApiResponse<string>>(cancellationToken: cancellationToken);

                logger.LogWarning($"Auth log error: {errorResult}");

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await Storage.DeleteAsync("token");

                    await Storage.DeleteAsync("username");

                    await Storage.DeleteAsync("jwt");

                    await Storage.DeleteAsync("signTime");

                    NavigationManager.NavigateTo("/account/login", true);
                }

                if (response.StatusCode == HttpStatusCode.Ambiguous)
                {
                    NavigationManager.NavigateTo("/settings/apisettings");
                }
            }
        }

        return response;
    }


    public async Task<ApiResponse<T>> PostAsync<T>(string uri, object data)
    {
        if (baseUri.HasNoValue())
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

        HttpRequestMessage request = new(HttpMethod.Post, baseUrl + uri);

        request.Content = byteContent;

        var resultStream = await SendAsync(request, new CancellationToken());

        Stream httpStream = await resultStream.Content.ReadAsStreamAsync();

        var result = await JsonSerializer.DeserializeAsync<ApiResponse<T>>(httpStream, option);

        return result;
    }
} 
