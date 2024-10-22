using Avhrm.Infrastructure.Client;

namespace Avhrm.UI.Shared.Pages;
public partial class ManageUser
{
    public bool IsMessageShown = false;
    public bool IsLoading = false;
    public List<string> MessageTexts = new();
    public List<GetAllUsersDto> Users;

    [Inject] private ApiHandler Api { get; set; }    

    protected override async Task OnInitializedAsync()
    {
        IsLoading = true;

        Users = (await Api.SendJsonAsync<GetAllUsersVm>(HttpMethod.Get
            , "account/GetAll")).Value.Data;

        IsLoading = false;
    }
}
