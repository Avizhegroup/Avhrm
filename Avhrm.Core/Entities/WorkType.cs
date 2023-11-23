using ProtoBuf;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Avhrm.Core.Entities;

[ProtoContract]
public class WorkType : IBaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [ProtoMember(1)]
    public int Id { get; set; }

    [ProtoMember(2)]
    public string Name { get; set; }

    [ProtoMember(3)]
    public DateTime CreateDateTime { get; set; }

    [ProtoMember(4)]
    public string CreatorUser { get; set; }

    [ProtoMember(5)]
    public DateTime? LastUpdateDateTime { get; set; }

    [ProtoMember(6)]
    public string? LastUpdateUser { get; set; }

    [ProtoMember(7)]
    public ICollection<WorkingReport> WorkingReports { get; set; }
}

public class WorkTypeConfig : IEntityTypeConfiguration<WorkType>
{
    public void Configure(EntityTypeBuilder<WorkType> builder)
    {
        builder.HasMany(p => p.WorkingReports)
               .WithOne(p => p.WorkType)
               .HasForeignKey(p => p.WorkTypeId);
    }
}
