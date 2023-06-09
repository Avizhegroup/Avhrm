﻿using Avhrm.Core.Features.Account.Query.GerUserLogin;
using Avhrm.Identity.Contracts;
using Avhrm.Identity.UI.Services;

namespace Avhrm.UI.Shared.Pages.Account;

public partial class Login
{
    public bool IsMessageShown = false;
    public string MessageText = string.Empty;

    public GetUserLoginQuery Request { get; set; } = new();

    [Inject] public IAuthenticationService AuthenticationService { get; set; } 
    [Inject] public AvhrmClientAuthenticationStateProvider ClientAuthProvider { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    public async Task OnValidSubmit(EditContext context)
    {
        string token = await AuthenticationService.Authenticate(Request);

        if (token.HasNoValue())
        {
            IsMessageShown = true;

            MessageText = TextResources.APP_StringKeys_Error_Login;

            return;
        }

        await ClientAuthProvider.SetUserAuthenticated(token);

        NavigationManager.NavigateTo("/", true);
    }
}
