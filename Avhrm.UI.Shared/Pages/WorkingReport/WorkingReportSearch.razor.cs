using Avhrm.Core.Contracts;
using Avhrm.Core.Features.WorkingReport.Query.GetUserWorkingReportByDate;

namespace Avhrm.UI.Shared.Pages.WorkingReport;
public partial class WorkingReportSearch
{
    public GetUserWorkingReportByDateQuery Request = new();

    [Inject] public IWorkingReportService Service { get; set; }

}
