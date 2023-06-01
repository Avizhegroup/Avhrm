using System.ComponentModel.DataAnnotations;

namespace Avhrm.Core;

public interface IBaseEntity
{
    int Id { get; set; }
    DateTime CreateDateTime { get; set; }
    string CreatorUser { get; set; }
    DateTime? LastUpdateDateTime { get; set; }
    string? LastUpdateUser { get; set; }
}
