using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Avhrm.Domains;
public class ApplicationUser : IdentityUser
{
    [Required]
    [StringLength(128)]
    public string PersianName { get; set; }

    public ApplicationUser? Parent { get; set; }
	public ICollection<ApplicationUser> Children { get; set; }

    public int DepartmentId { get; set; }
    public Department Department { get; set; }
}
