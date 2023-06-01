using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Avhrm.Identity.Server.Models;

public class ApplicationUser : IdentityUser
{
    [Required]
    [StringLength(128)]
    public string PersianName { get; set; }

    public ApplicationUser? Parent { get; set; }
	public ICollection<ApplicationUser> Children { get; set; }
}
