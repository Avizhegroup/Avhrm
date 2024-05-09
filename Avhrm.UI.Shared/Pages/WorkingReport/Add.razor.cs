using Avhrm.Core.Common;
using Avhrm.Core.Contracts;
using Avhrm.Core.Features.Project.Query.GetAllProjects;
using Avhrm.Core.Features.WorkingReport.Command;
using Avhrm.Core.Features.WorkType.Query.GetAllWorkTypes;
using Avhrm.Domains;
using Microsoft.AspNetCore.Components.Web;

namespace Avhrm.UI.Shared.Pages.WorkingReport;
public partial class Add
{
    public bool IsMessageShown = false;
    public List<GetAllWorkTypesVm> WorkTypes = new();
    public List<GetAllProjectsVm> Projects = new();
    public SaveWorkReportCommand Command = new();  
    public List<string> MessageTexts = new();

    [Parameter] public int? Id { get; set; }

    [Inject] public IWorkTypeService WorkTypeService { get; set; }
    [Inject] public IWorkReportService WorkReportService { get; set; }
    [Inject] public IProjectService ProjectService { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        WorkTypes = await WorkTypeService.GetAllWorkTypes();

        Projects = await ProjectService.GetAllProjects();

        if (Id is not null)
        {
            Command = await WorkReportService.GetWorkReportById(new()
            {
                Id = Id.Value
            });
        }
        else
        {
            Command.PersianDate = PersianCalendarTools.GregorianToPersian(DateTime.Now);
        }
    }

    public async Task OnValidSubmit(EditContext context)
    {
        BaseDto<bool> result;

        if (Id is not null)
        {
            result = await WorkReportService.UpdateWorkReport(Command);
        }
        else
        {
            result = await WorkReportService.InsertWorkReport(Command);
        }

        if (result.Value)
        {
            NavigationManager.NavigateTo("/workingreport/search");

            return;
        }
    }

    public async Task OnInvalidSubmit(EditContext context)
    {
        IsMessageShown = true;

        MessageTexts.Clear();

        foreach (var valid in context.GetValidationMessages())
        {
            MessageTexts.Add(valid);
        }
    }

    public async Task OnDeleteClick(MouseEventArgs e)
    {
        BaseDto<bool> result = await WorkReportService.DeleteWorkReport(Command);

        if (result.Value)
        {
            NavigationManager.NavigateTo("/workingreport/search");

            return;
        }
    }
}
