using Avhrm.Application.Common;
using Avhrm.Application.Contracts;
using Avhrm.Application.Dtos;
using Avhrm.Application.Features.Customer.Query.GetAllCustomers;
using Avhrm.Application.Features.Project.Query.GetAllProjects;
using Avhrm.Application.Features.WorkChallenge.Query.GetAllWorkChallenge;
using Avhrm.Application.Features.WorkingReport.Command.SaveWorkReport;
using Avhrm.Application.Features.WorkingReport.Enum;
using Avhrm.Application.Features.WorkType.Query.GetAllWorkTypes;
using Microsoft.AspNetCore.Components.Web;

namespace Avhrm.UI.Shared.Pages.WorkingReport;
public partial class Add
{
    public bool IsMessageShown = false;
    public bool IsLoading = true;
    public List<GetAllWorkTypesVm> WorkTypes = new();
    public List<GetAllProjectsVm> Projects = new();
    public List<GetAllCustomersVm> Customers = new();
    public List<GetAllWorkChallengeVm> WorkChallenges = new();
    public SaveWorkReportCommand Command = new();  
    public List<string> MessageTexts = new();
    public List<DropDownDualItem<WorkReportTimeOfDay>> TimeOfDays = new()
    {
        new()
        {
            Name = TextResources.APP_StringKeys_Morning,
            Value = WorkReportTimeOfDay.Morning
        },
        new()
        {
            Name = TextResources.APP_StringKeys_Noon,
            Value = WorkReportTimeOfDay.Noon
        },
        new()
        {
            Name = TextResources.APP_StringKeys_Afternoon,
            Value = WorkReportTimeOfDay.Afternoon
        }
    };
    public Severity AlertSeverity = Severity.Error;

    [Parameter] public int? Id { get; set; }

    [Inject] public IWorkTypeService WorkTypeService { get; set; }
    [Inject] public IWorkReportService WorkReportService { get; set; }
    [Inject] public IProjectService ProjectService { get; set; }
    [Inject] public ICustomerService CustomerService { get; set; }
    [Inject] public IWorkChallengeService WorkChallengeService { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        WorkTypes = await WorkTypeService.GetWorkTypesByDepartmentId();

        Projects = await ProjectService.GetAllProjects();

        Customers = await CustomerService.GetAllCustomers();

        WorkChallenges = await WorkChallengeService.GetWorkChallengesByDepartmentId();

        Command.PersianDate = PersianCalendarTools.GregorianToPersian(DateTime.Now);

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

        IsLoading = false;
    }

    public async Task OnValidSubmit(EditContext context)
    {
        BaseDto<bool> result;

        IsLoading = true;

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
            AlertSeverity = Severity.Success;

            MessageTexts = new()
            {
                TextResources.APP_StringKeys_Message_Success
            };

            
        }
        else
        {
            AlertSeverity = Severity.Error;

            MessageTexts = new()
            {
                TextResources.APP_StringKeys_Message_Failed
            };
        }

        IsLoading = false;

        IsMessageShown = true;
    }

    public async Task OnInvalidSubmit(EditContext context)
    {
        MessageTexts.Clear();

        foreach (var valid in context.GetValidationMessages())
        {
            MessageTexts.Add(valid);
        }

        AlertSeverity = Severity.Error;

        IsMessageShown = true;
    }

    public async Task OnDeleteClick(MouseEventArgs e)
    {
        BaseDto<bool> result = await WorkReportService.DeleteWorkReport(new()
        {
            Id = Command.Id
        });

        if (result.Value)
        {
            NavigationManager.NavigateTo("/workingreport/search");

            return;
        }
    }
}
