using ProtoBuf;
using System.ComponentModel.DataAnnotations;

namespace Avhrm.Core.Entities;

[ProtoContract]
public class VacationRequest : IBaseEntity
{
    [Key]
    [ProtoMember(1)]
    public Guid Id { get; set; }

    [Required]
    [ProtoMember(2)]
    public DateTime FromDateTime { get; set; }

    [Required]
    [ProtoMember(3)]
    public DateTime ToDateTime { get; set; }

    [StringLength(256)]
    [ProtoMember(4)]
    public string? Description { get; set; }

    [Required]
    [ProtoMember(5)]
    public bool IsVerified { get; set; }

    [ProtoMember(6)]
    public Guid? Verifier { get; set; }

    [ProtoMember(7)]
    public DateTime? VerifyDateTime { get; set; }

    [ProtoMember(8)]
    public DateTime CreateDateTime { get; set; }

    [Required]
    [ProtoMember(9)]
    public Guid CreatorUser { get; set; }

    [ProtoMember(10)]
    public DateTime? LastUpdateDateTime { get; set; }

    [ProtoMember(11)]
    public Guid? LastUpdateUser { get; set; }
}
