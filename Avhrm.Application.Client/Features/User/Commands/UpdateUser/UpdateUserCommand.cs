namespace Avhrm.Application.Client.Features;
public class UpdateUserCommand :IRequest<UpdateUserVm>
{
    [Required]
    [StringLength(256)]
    public string Username { get; set; }

    [Required]
    [StringLength(128)]
    public string PersianName { get; set; }

    [Required]
    [StringLength(20)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    public int DepartmentId { get; set; }
}
