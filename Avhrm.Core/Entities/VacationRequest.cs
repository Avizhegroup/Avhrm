using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Avhrm.Core.Entities;

[DataContract]
public class VacationRequest : BaseEntity
{
    [Required]
    [DataMember(Order = 1)]
    public DateTime FromDateTime { get; set; }

    [Required]
    [DataMember(Order = 2)]
    public DateTime ToDateTime { get; set; }

    [StringLength(256)]
    [DataMember(Order = 3)]
    public string? Description { get; set; }

    [Required]
    [DataMember(Order = 4)]
    public bool IsVerified { get; set; }

    [DataMember(Order = 5)]
    public Guid? Verifier { get; set; }

    [DataMember(Order = 6)]
    public DateTime? VerifyDateTime { get; set; }
}
