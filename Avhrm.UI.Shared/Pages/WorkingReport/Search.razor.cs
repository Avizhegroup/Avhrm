using Avhrm.Core.Contracts;
using Avhrm.Core.Features.WorkingReport.Query.GetUserWorkingReportByDate;

namespace Avhrm.UI.Shared.Pages.WorkingReport;
public partial class Search
{
    public bool IsLoading = false;
    public GetUserWorkingReportByDateQuery Request = new();
    public List<GetUserWorkingReportByDateVm> Reports;

    [Inject] public IWorkReportService Service { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Request.Date = DateTime.Now;
    }

    public async Task OnValidSubmit(EditContext context)
    {
        IsLoading = true;
        
        Reports = await Service.GetWorkingReportByDate(Request);

        IsLoading = false;
    }
}
