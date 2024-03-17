using Avhrm.Core.Contracts;
using Avhrm.Core.Features.WorkingReport.Query.GetUserWorkingReportByDate;
using Microsoft.AspNetCore.Components.Web;

namespace Avhrm.UI.Shared.Pages.WorkingReport;
public partial class Search
{
    public GetUserWorkingReportByDateQuery Request = new();
    public List<Avhrm.Core.Entities.WorkingReport> Reports;

    [Inject] public IWorkingReportService Service { get; set; }

    public async Task OnValidSubmit(EditContext context)
    {
        Reports = await Service.GetWorkingReportByDate(Request);
    }
}
