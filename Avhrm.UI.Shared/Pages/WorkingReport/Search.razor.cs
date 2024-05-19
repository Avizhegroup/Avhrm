using Avhrm.Core.Contracts;
using Avhrm.Core.Features.WorkingReport.Query.GetUserWorkingReportByDate;

namespace Avhrm.UI.Shared.Pages.WorkingReport;
public partial class Search
{
    public bool IsMessageShown = false;
    public bool IsLoading = false;
    public List<string> MessageTexts = new();
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

    public async Task OnInvalidSubmit(EditContext context)
    {
        MessageTexts.Clear();

        foreach (var valid in context.GetValidationMessages())
        {
            MessageTexts.Add(valid);
        }

        IsMessageShown = true;
    }
}
