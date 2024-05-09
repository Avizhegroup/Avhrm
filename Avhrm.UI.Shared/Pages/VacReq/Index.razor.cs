using Avhrm.Core.Contracts;
using Avhrm.Domains;

namespace Avhrm.UI.Shared.Pages.VacReq;

public partial class Index
{
    public bool IsLoading = true;
    public List<VacationRequest> VacationRequests;

    [Inject] public IVacationRequest VacReqServices { get; set; }

    protected override async Task OnInitializedAsync()
    {
        VacationRequests = await VacReqServices.GetVacationRequests();

        IsLoading = false;
    }
}
