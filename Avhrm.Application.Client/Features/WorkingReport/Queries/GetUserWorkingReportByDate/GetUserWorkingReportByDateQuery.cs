namespace Avhrm.Application.Client.Features;
public class GetUserWorkingReportByDateQuery:IRequest<GetUserWorkingReportByDateVm>
{
    [Required(ErrorMessageResourceType = typeof(TextResources), ErrorMessageResourceName = nameof(TextResources.APP_StringKeys_Error_Required))]
    [Display(ResourceType = typeof(TextResources), Name = nameof(TextResources.APP_StringKeys_Date))]
    public DateTime? Date { get; set; }
}
