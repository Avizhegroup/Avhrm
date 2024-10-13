namespace Avhrm.Application.Client.Features; 
public class GetVacationRequestByIdVm 
{
    public int Id { get; set; }
    public DateTime FromDateTime { get; set; }
    public DateTime ToDateTime { get; set; }
    public string? Description { get; set; }
    public bool IsVerified { get; set; }
}
