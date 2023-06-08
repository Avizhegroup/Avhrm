using Avhrm.Core.Contracts;
using Avhrm.Core.Entities;
using Microsoft.AspNetCore.Components;

namespace Avhrm.UI.Shared.Pages.VacReq;

public partial class Add
{
    public VacationRequest Request { get; set; } = new();

    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public IVacationRequest VacReqService { get; set; }

    public async Task OnValidSubmit(EditContext context)
    {
        var result = await VacReqService.InsertVacationRequest(Request);

        if (result.Value)
        {
            NavigationManager.NavigateTo("/vacreq");
        }
    }
}
