using Avhrm.Core.Contracts;
using Avhrm.Core.Features.WorkingReport.Query.GetUserWorkingReportByDate;

namespace Avhrm.UI.Shared.Pages.WorkingReport;
public partial class Search
{
    public GetUserWorkingReportByDateQuery Request = new();
    public List<GetUserWorkingReportByDateVm> Reports;

    [Inject] public IWorkReportService Service { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Request.Date = PersianCalendarTools.GregorianToPersian(DateTime.Now);
    }

    public async Task OnValidSubmit(EditContext context)
    {
        Reports = await Service.GetWorkingReportByDate(Request);
    }
}
