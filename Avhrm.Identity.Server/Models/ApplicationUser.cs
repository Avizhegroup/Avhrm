using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Avhrm.Identity.Server.Models;

public class ApplicationUser : IdentityUser
{
    [Required]
    [StringLength(128)]
    public string PersianName { get; set; }

    public Guid? ParentUserId { get; set; }
	public ApplicationUser ParentUser { get; set; }

	public ICollection<ApplicationUser> ChildUsers { get; set; }
}
