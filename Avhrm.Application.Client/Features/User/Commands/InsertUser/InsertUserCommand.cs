namespace Avhrm.Application.Client.Features;
public class InsertUserCommand : IRequest<InsertUserVm>
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

    [Required]
    public string ParentId { get; set; }

    [Required]
    public string RoleId { get; set; }
}
