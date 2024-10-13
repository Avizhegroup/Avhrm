namespace Avhrm.Application.Client.Features;
public class DeleteVacationRequestCommand : IRequest<DeleteVacationRequestVm>
{
    [Required(ErrorMessageResourceType = typeof(TextResources), ErrorMessageResourceName = nameof(TextResources.APP_StringKeys_Error_Required))]
    public int Id { get; set; }
}
