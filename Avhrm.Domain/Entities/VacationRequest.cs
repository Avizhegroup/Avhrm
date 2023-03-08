using Avhrm.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Avhrm.Domain.Entities;

public class VacationRequest : BaseEntity
{
    [Required]
    public DateTime FromDateTime { get; set; }

    [Required]
    public DateTime ToDateTime { get; set; }

    [StringLength(256)]
    public string? Description { get; set; }

    [Required]
    public bool IsVerified { get; set; }
    public Guid? Verifier { get; set; }
    public DateTime? VerifyDateTime { get; set; }

}
