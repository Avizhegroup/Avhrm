using Avhrm.Application.Client;
using Avhrm.Identity.UI.Services;
using Avhrm.Infrastructure.Client;

namespace Avhrm.UI.Shared.Pages.Account;
public partial class Login
{
    public bool IsMessageShown = false;
    public bool IsLoading = false;
    public List<string> MessageTexts = new();

    public GetUserLoginQuery Request { get; set; } = new();

    [Inject] public AvhrmClientAuthenticationStateProvider ClientAuthProvider { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public ApiHandler Api { get; set; }

    [CascadingParameter] public ComponentsContext Context { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Context.IsDrawerShown = false;

        Context.IsBackButtonShown = false;

#if DEBUG
        Request = new()
        {
            Username = "11",
            Password = "rfidadmin"
        };
#endif
    }

    public async Task OnValidSubmit(EditContext context)
    {
        IsLoading = true;

        var result = (await Api.SendJsonAsync<GetUserLoginVm>(HttpMethod.Post
            , "account/AuthenticateByPassword"
            , Request)).Value;

        if (result.Token.HasNoValue())
        {
            IsMessageShown = true;

            MessageTexts.Clear();

            MessageTexts.Add(TextResources.APP_StringKeys_Error_Login);

            IsLoading = false;

            return;
        }

        await ClientAuthProvider.SetUserAuthenticated(result.Token);

        IsLoading = false;

        NavigationManager.NavigateTo("/", true);
    }

    public async Task OnInvalidSubmit(EditContext context)
    {
        IsMessageShown = true;

        MessageTexts.Clear();

        foreach (var valid in context.GetValidationMessages())
        {
            MessageTexts.Add(valid); 
        }
    }
}
