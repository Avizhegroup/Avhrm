using Avhrm.Core.Common;
using Avhrm.Core.Contracts;
using Avhrm.Core.Entities;
using Microsoft.AspNetCore.Components.Web;

namespace Avhrm.UI.Shared.Pages.VacReq;

public partial class Add
{
    public bool IsLoading = true;
    public VacationRequest Request { get; set; } = new();

    [CascadingParameter] public TelerikNotification Notification { get; set; }

    [Parameter] public int? Id { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public IVacationRequest VacReqService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (Id is not null)
        {
            Request = await VacReqService.GetVacationRequestById(new()
            {
                Value = Id.Value
            });
        }

        IsLoading = false;
    }

    public async Task OnValidSubmit(EditContext context)
    {
        IsLoading = true;

        BaseDto<bool> result;

        if (Id is not null)
        {
            result = await VacReqService.UpdateVacationRequest(Request);
        }
        else
        {
            result = await VacReqService.InsertVacationRequest(Request);
        }

        if (result.Value)
        {
            Notification.Show(TextResources.APP_StringKeys_Message_Success, "succes");

            NavigationManager.NavigateTo("/vacreq");

            return;
        }

        Notification.Show(TextResources.APP_StringKeys_Error_Fail, "error");

        IsLoading = false;
    }

    public async Task OnDeleteClick(MouseEventArgs e)
    {
        IsLoading = true;

        BaseDto<bool> result = await VacReqService.DeleteVacationRequest(Request);

        if (result.Value)
        {
            Notification.Show(TextResources.APP_StringKeys_Message_Success, "succes");

            NavigationManager.NavigateTo("/vacreq");

            return;
        }

        Notification.Show(TextResources.APP_StringKeys_Error_Fail, "error");

        IsLoading = false;
    }
}
