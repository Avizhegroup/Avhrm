using ProtoBuf;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Avhrm.Core.Entities;

[ProtoContract]
public class WorkReport : IBaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [ProtoMember(1)]
    public int Id { get; set; }

    [ProtoMember(2)]
    [StringLength(10)]
    public string PersianDate { get; set; }

    [ProtoMember(3)]
    [StringLength(512)]
    public string Desc { get; set; }

    [ProtoMember(4)]
    public decimal SpentHours { get; set; }

    [ProtoMember(5)]
    public int ProjectId { get; set; }

    [ProtoMember(6)]
    public Project Project { get; set; }

    [ProtoMember(7)]
    public int WorkTypeId { get; set; }

    [ProtoMember(8)]
    public WorkType WorkType { get; set; }

    [ProtoMember(9)]
    public WorkDayType WorkDayType { get; set; }

    [ProtoMember(10)]
    public string WorkDayDateTime { get; set; }

    [ProtoMember(11)]
    public DateTime CreateDateTime { get; set; }

    [ProtoMember(12)]
    public string CreatorUser { get; set; }

    [ProtoMember(13)]
    public DateTime? LastUpdateDateTime { get; set; }

    [ProtoMember(14)]
    public string? LastUpdateUser { get; set; }
}

public enum WorkDayType
{
    WorkDay,
    Holiday
}