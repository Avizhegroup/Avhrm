using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avhrm.Domains;
public class VacationRequest : IBaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public DateTime FromDateTime { get; set; }

    [Required]
    public DateTime ToDateTime { get; set; }

    [StringLength(256)]
    public string? Description { get; set; }

    public bool IsVerified { get; set; }

    public string? Verifier { get; set; }

    public DateTime? VerifyDateTime { get; set; }

    public DateTime CreateDateTime { get; set; }

    public string CreatorUserId { get; set; }

    public DateTime? LastUpdateDateTime { get; set; }

    public string? LastUpdateUserId { get; set; }

    [Required(ErrorMessageResourceType = typeof(TextResources), ErrorMessageResourceName = nameof(TextResources.APP_StringKeys_Error_Required))]
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
