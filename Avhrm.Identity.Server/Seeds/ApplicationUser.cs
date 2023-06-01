using Avhrm.Identity.Server.Models;
using Avhrm.Identity.Server.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Avhrm.Identity.Server.Seeds;

public static class SeedApplicationUser
{
    public static void SeedApplicationUserData(this ModelBuilder modelBuilder)
    {
        string adminId = "6f236e65-88a2-4530-aa66-b1fa9eef0c88";
        string adminRoleId = "cb383b16-dfc9-487f-b4bb-053eab408d8e";

        modelBuilder.Entity<ApplicationUser>()
                    .HasData(new ApplicationUser()
                    {
                        Id = adminId,
                        UserName = "Admin",
                        NormalizedUserName = "admin",
                        PersianName = "مدیر سیستم",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        PasswordHash = CryptographyTools.GetHashedStringSha256StringBuilder("hrmadmin"),
                    });

        modelBuilder.Entity<IdentityRole>()
                    .HasData(new IdentityRole()
                    {
                        Id = adminRoleId,
                        Name = "Admin",
                        NormalizedName = "کاربر مدیر"
                    });

        modelBuilder.Entity<IdentityUserRole<string>>()
                    .HasData(new IdentityUserRole<string>()
                    {
                        RoleId = adminRoleId,
                        UserId = adminId
                    });
    }
}
