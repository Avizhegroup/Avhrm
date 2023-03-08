using Microsoft.AspNetCore.Identity;

namespace Avhrm.Identity.Models;

public class ApplicationUser : IdentityUser
{
	public Guid? ParentUserId { get; set; }
	public ApplicationUser ParentUser { get; set; }

	public ICollection<ApplicationUser> ChildUsers { get; set; }
}
