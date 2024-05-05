using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Avhrm.Domains;
public class WorkChallenge : IBaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(256)]
    public string Description { get; set; }

    [Required]
    public int DepartmentId { get; set; }
    public Department Department { get; set; }

    public ICollection<WorkReport> WorkReports { get; set; }

    public DateTime CreateDateTime { get; set; }
    public string CreatorUserId { get; set; }
    public DateTime? LastUpdateDateTime { get; set; }
    public string? LastUpdateUserId { get; set; }
}
