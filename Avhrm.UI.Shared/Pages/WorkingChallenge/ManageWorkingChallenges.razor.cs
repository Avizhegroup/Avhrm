using Avhrm.Domains;
using Avhrm.Infrastructure.Client;

namespace Avhrm.UI.Shared.Pages.WorkingChallenge;
public partial class ManageWorkingChallenges
{
    public bool IsMessageShown = false;
    public bool IsLoading = false;
    public List<string> MessageTexts = new();
    public Severity AlertSeverity = Severity.Error;
    public List<GetAllDepartmentDto> Departments = new();
    public List<GetAllWorkChallengeDto> AllWorkChallenges;
    public List<GetAllWorkChallengeDto> ShownWorkChallenges=new();
    public InsertWorkChallengeCommand Command = new();

    [Inject] public ApiHandler Api { get; set; }

    [CascadingParameter] public ComponentsContext Context { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Context.IsBackButtonShown = true;

        IsLoading = true;

        Departments = (await Api.SendJsonAsync<GetAllDepartmentVm>(HttpMethod.Get
            , "Department/GetAll")).Value.Data;

        AllWorkChallenges = (await Api.SendJsonAsync<GetAllWorkChallengeVm>(HttpMethod.Get
            , "WorkChallenge/GetAll")).Value.Data;

        IsLoading = false;
    }

    public async Task OnDeleteWorkChallengeClick(int id)
    {
        IsLoading = true;

        bool result = (await Api.SendJsonAsync<DeleteWorkChallengeVm>(HttpMethod.Delete
            , "WorkChallenge/Delete"
            , new DeleteWorkChallengeCommand()
            {
                Id = id
            })).Value.Result;

        if (result)
        {
            AlertSeverity = Severity.Success;

            MessageTexts = new()
            {
                TextResources.APP_StringKeys_Message_Success
            };

            AllWorkChallenges.RemoveAll(x => x.Id == id);   
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
    }

    public async Task OnValidSubmit(EditContext context)
    {
        bool result;

        IsLoading = true;

            result = (await Api.SendJsonAsync<InsertWorkChallengeVm>(HttpMethod.Post
                , "WorkChallenge/Insert"
                , Command)).Value.Result;

        if (result)
        {
            AllWorkChallenges = (await Api.SendJsonAsync<GetAllWorkChallengeVm>(HttpMethod.Get
            , "WorkChallenge/GetAll")).Value.Data;

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
}
