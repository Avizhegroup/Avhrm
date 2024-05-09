using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Avhrm.Domains;
public class UserPointChangeLog : IBaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int BeforePoint { get; set; }

    [Required]
    public int AfterPoint { get; set; }

    [Required]
    public int UserId { get; set; }
    public ApplicationUser User { get; set; }

    public DateTime CreateDateTime { get; set; }
    public string CreatorUserId { get; set; }
    public DateTime? LastUpdateDateTime { get; set; }
    public string? LastUpdateUserId { get; set; }
}
