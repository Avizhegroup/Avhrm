namespace Avhrm.Application.Client.Features;
public class GetUserByUsernameVm
{
    public string Username { get; set; }
    public string PersianName { get; set; }
    public string Password { get; set; }
    public int DepartmentId { get; set; }
    public int ParentId { get; set; }
}
