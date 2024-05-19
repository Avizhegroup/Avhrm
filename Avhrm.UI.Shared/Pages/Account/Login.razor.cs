using Avhrm.Core.Features.Account.Query.GerUserLogin;
using Avhrm.Identity.Contracts;
using Avhrm.Identity.UI.Services;

namespace Avhrm.UI.Shared.Pages.Account;
public partial class Login
{
    public bool IsMessageShown = false;
    public bool IsLoading = false;
    public List<string> MessageTexts = new();

    public GetUserLoginQuery Request { get; set; } = new();

    [Inject] public IAuthenticationService AuthenticationService { get; set; } 
    [Inject] public AvhrmClientAuthenticationStateProvider ClientAuthProvider { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }
   
    [CascadingParameter] public ComponentsContext Context { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Context.IsDrawerShown = false;
    }

    public async Task OnValidSubmit(EditContext context)
    {
        IsLoading = true;

        var token = await AuthenticationService.Authenticate(Request);

        if (token.Value.HasNoValue())
        {
            IsMessageShown = true;

            MessageTexts.Clear();

            MessageTexts.Add( TextResources.APP_StringKeys_Error_Login);

            IsLoading = false;

            return;
        }

        await ClientAuthProvider.SetUserAuthenticated(token.Value);

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
