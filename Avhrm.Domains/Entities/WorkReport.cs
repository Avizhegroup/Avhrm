using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Avhrm.Domains;
public class WorkReport : IBaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(10)]
    public string PersianDate { get; set; }

    [StringLength(512)]
    public string? Desc { get; set; }
    public decimal SpentHours { get; set; }
   
    public int ProjectId { get; set; }
    public Project Project { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public int WorkTypeId { get; set; }
    public WorkType WorkType { get; set; }
    public WorkDayType WorkDayType { get; set; }
    public DateTime? WorkDayDateTime { get; set; }

    public DateTime CreateDateTime { get; set; }
    public string CreatorUserId { get; set; }
    public DateTime? LastUpdateDateTime { get; set; }
    public string? LastUpdateUserId { get; set; }
}

public enum WorkDayType
{
    WorkDay,
    Holiday
}