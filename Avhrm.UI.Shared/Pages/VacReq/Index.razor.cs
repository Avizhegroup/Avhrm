using Avhrm.Core.Contracts;
using Avhrm.Core.Entities;

namespace Avhrm.UI.Shared.Pages.VacReq;

public partial class Index
{
    public List<VacationRequest> VacationRequests;

    [Inject] public IVacationRequest VacReqServices { get; set; }

    protected override async Task OnInitializedAsync()
    {
        VacationRequests = await VacReqServices.GetVacationRequests();
    }
}
