namespace Avhrm.Application.Client.Features;
public class InsertWorkChallengeCommand : IRequest<InsertWorkChallengeVm>  
{
    [Required]
    public int DepartmentId { get; set; }

    [Required]
    [StringLength(256)]
    public string Description { get; set; }
}
