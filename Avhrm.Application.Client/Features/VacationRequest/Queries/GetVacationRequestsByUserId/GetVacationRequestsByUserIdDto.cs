namespace Avhrm.Application.Client.Features;
public class GetVacationRequestsByUserIdDto
{
    public int Id { get; set; }

    [StringLength(256)]
    public string? Description { get; set; }

    public bool IsVerified { get; set; }
    public DateTime CreateDateTime { get; set; }
    public string CreatorUserId { get; set; }
}
