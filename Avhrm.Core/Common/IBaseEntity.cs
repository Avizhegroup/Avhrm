using System.ComponentModel.DataAnnotations;

namespace Avhrm.Core;

public interface IBaseEntity
{
    Guid Id { get; set; }
    DateTime CreateDateTime { get; set; }
    Guid CreatorUser { get; set; }
    DateTime? LastUpdateDateTime { get; set; }
    Guid? LastUpdateUser { get; set; }
}
