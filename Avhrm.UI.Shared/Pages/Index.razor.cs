using Microsoft.AspNetCore.Components.Web;

namespace Avhrm.UI.Shared.Pages;

public partial class Index
{
    [Inject] public NavigationManager NavigationManager { get; set; }

    public async Task OnVaqReqIndexClick(MouseEventArgs e)
    {
        NavigationManager.NavigateTo("/vacreq");
    }
}
