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
}
