using Avhrm.Infrastructure.Client;

namespace Avhrm.UI.Shared.Pages.WorkingReport;
public partial class Search
{
    public bool IsMessageShown = false;
    public bool IsLoading = false;
    public List<string> MessageTexts = new();
    public GetUserWorkingReportByDateQuery Request = new();
    public List<GetUserWorkingReportByDateDto> Reports;

    [Inject] public ApiHandler Api { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Request.Date = DateTime.Now;
    }

    public async Task OnValidSubmit(EditContext context)
    {
        IsLoading = true;

        Reports = (await Api.SendJsonAsync<GetUserWorkingReportByDateVm>(HttpMethod.Get
            , "WorkReport/GetByDate"
            , Request)).Value.Data;

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
