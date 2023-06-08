using Avhrm.Core.Common;
using Avhrm.Core.Contracts;
using Avhrm.Core.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Avhrm.UI.Shared.Pages.VacReq;

public partial class Add
{
    public VacationRequest Request { get; set; } = new();

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
    }

    public async Task OnValidSubmit(EditContext context)
    {
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
            NavigationManager.NavigateTo("/vacreq");
        }
    }

    public async Task OnDeleteClick(MouseEventArgs e)
    {
        BaseDto<bool> result  = await VacReqService.DeleteVacationRequest(Request);

        if (result.Value)
        {
            NavigationManager.NavigateTo("/vacreq");
        }
    }
}
