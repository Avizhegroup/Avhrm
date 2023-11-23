using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Avhrm.Core.Entities;

[ProtoContract]
public class VacationRequest : IBaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [ProtoMember(1)]
    public int Id { get; set; }

    [Required]
    [ProtoMember(2)]
    public DateTime FromDateTime { get; set; }

    [Required]
    [ProtoMember(3)]
    public DateTime ToDateTime { get; set; }

    [StringLength(256)]
    [ProtoMember(4)]
    public string? Description { get; set; }

    [ProtoMember(5)]
    public bool IsVerified { get; set; }

    [ProtoMember(6)]
    public string? Verifier { get; set; }

    [ProtoMember(7)]
    public DateTime? VerifyDateTime { get; set; }

    [ProtoMember(8)]
    public DateTime CreateDateTime { get; set; }

    [ProtoMember(9)]
    public string CreatorUser { get; set; }

    [ProtoMember(10)]
    public DateTime? LastUpdateDateTime { get; set; }

    [ProtoMember(11)]
    public string? LastUpdateUser { get; set; }

    [Required(ErrorMessageResourceType = typeof(TextResources), ErrorMessageResourceName = nameof(TextResources.APP_StringKeys_Error_Required))]
    [Display(ResourceType = typeof(TextResources), Name = nameof(TextResources.APP_StringKeys_FromDate))]
    [NotMapped]
    public string PersianFromDate
    {
        get => PersianCalendarTools.GregorianToPersian(FromDateTime);
        set
        {
            FromDateTime = PersianCalendarTools.PersianToGregorian(value);
        }
    }

    [Required(ErrorMessageResourceType = typeof(TextResources), ErrorMessageResourceName = nameof(TextResources.APP_StringKeys_Error_Required))]
    [Display(ResourceType = typeof(TextResources), Name = nameof(TextResources.APP_StringKeys_ToDate))]
    [NotMapped]
    public string PersianToDate
    {
        get => PersianCalendarTools.GregorianToPersian(ToDateTime);
        set
        {
            ToDateTime = PersianCalendarTools.PersianToGregorian(value);
        }
    }

    [Required(ErrorMessageResourceType = typeof(TextResources), ErrorMessageResourceName = nameof(TextResources.APP_StringKeys_Error_Required))]
    [Display(ResourceType = typeof(TextResources), Name = nameof(TextResources.APP_StringKeys_FromTime))]
    [NotMapped]
    public string PersianFromTime
    {
        get => FromDateTime.ToString("HH:mm");
        set
        {
            var splited = value.Split(':');

            FromDateTime = FromDateTime.AddHours(int.Parse(splited[0])).AddMinutes(int.Parse(splited[1])); 
        }
    }

    [Required(ErrorMessageResourceType = typeof(TextResources), ErrorMessageResourceName = nameof(TextResources.APP_StringKeys_Error_Required))]
    [Display(ResourceType = typeof(TextResources), Name = nameof(TextResources.APP_StringKeys_ToTime))]
    [NotMapped]
    public string PersianToTime
    {
        get => ToDateTime.ToString("HH:mm");
        set
        {
            var splited = value.Split(':');

            ToDateTime = ToDateTime.AddHours(int.Parse(splited[0])).AddMinutes(int.Parse(splited[1]));
        }
    }
}
