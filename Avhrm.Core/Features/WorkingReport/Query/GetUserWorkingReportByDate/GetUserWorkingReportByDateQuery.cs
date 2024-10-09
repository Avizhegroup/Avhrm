using ProtoBuf;
using System.ComponentModel.DataAnnotations;

namespace Avhrm.Application.Features.WorkingReport.Query.GetUserWorkingReportByDate;

[ProtoContract]
public class GetUserWorkingReportByDateQuery
{
    [ProtoMember(1)]
    [Required(ErrorMessageResourceType = typeof(TextResources), ErrorMessageResourceName = nameof(TextResources.APP_StringKeys_Error_Required))]
    [Display(ResourceType = typeof(TextResources), Name = nameof(TextResources.APP_StringKeys_Date))]
    public DateTime? Date { get; set; }
}
