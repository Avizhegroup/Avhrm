using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProtoBuf;

namespace Avhrm.Core.Entities;

[ProtoContract]
public class Project : IBaseEntity
{
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
    public ICollection<WorkReport> WorkingReports { get; set; }
}

public class ProjectConfig : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasMany(p => p.WorkingReports)
               .WithOne(p => p.Project)
               .HasForeignKey(p => p.ProjectId);
    }
}

