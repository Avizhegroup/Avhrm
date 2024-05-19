namespace Avhrm.Domains;

public interface IBaseEntity
{
    int Id { get; set; }
    DateTime CreateDateTime { get; set; }
    string CreatorUserId { get; set; }
    DateTime? LastUpdateDateTime { get; set; }
    string? LastUpdateUserId { get; set; }
}
