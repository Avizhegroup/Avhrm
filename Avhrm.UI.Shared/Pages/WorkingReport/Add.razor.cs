using Avhrm.Core.Contracts;
using Avhrm.Core.Entities;

namespace Avhrm.UI.Shared.Pages.WorkingReport;

public partial class Add
{
    public List<WorkType> WorkTypes;
    public WorkReport Request = new();  

    [Parameter] public int? Id { get; set; }

    [Inject] public IWorkTypeService WorkTypeService { get; set; }
    [Inject] public IWorkReportService WorkReportService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        WorkTypes = await WorkTypeService.GetAllWorkTypes();

        if (Id is not null)
        {
            Request = await WorkReportService.GetWorkReportById(new()
            {
                Id = Id.Value
            });
        }
        else
        {
            Request.PersianDate = PersianCalendarTools.GregorianToPersian(DateTime.Now);
        }
    }
}
