using Avhrm.Core.Contracts;

namespace Avhrm.UI.Shared.Pages.VacReq;

public partial class Index
{
    [Inject] public IVacationRequest VacReqServices { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await VacReqServices.GetVacationRequests();
    }
}
