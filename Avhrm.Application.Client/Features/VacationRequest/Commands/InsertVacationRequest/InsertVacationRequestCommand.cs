namespace Avhrm.Application.Client.Features;
public class InsertVacationRequestCommand : IRequest<InsertVacationRequestVm>
{
    [Required(ErrorMessageResourceType = typeof(TextResources), ErrorMessageResourceName = nameof(TextResources.APP_StringKeys_Error_Required))]
    public string PersianFromDate { get; set; }

    [Required(ErrorMessageResourceType = typeof(TextResources), ErrorMessageResourceName = nameof(TextResources.APP_StringKeys_Error_Required))]
    public string PersianToDate { get; set; }

    [Required(ErrorMessageResourceType = typeof(TextResources), ErrorMessageResourceName = nameof(TextResources.APP_StringKeys_Error_Required))]
    public string PersianFromTime { get; set; }

    [Required(ErrorMessageResourceType = typeof(TextResources), ErrorMessageResourceName = nameof(TextResources.APP_StringKeys_Error_Required))]
    public string PersianToTime { get; set; }

    [StringLength(256)]
    public string? Description { get; set; }
}
