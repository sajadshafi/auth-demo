using AuthDemo.Constants;
using Microsoft.AspNetCore.Identity;

namespace AuthDemo.Domain
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? Name { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        internal static (ApplicationUser, ApplicationRole, IdentityUserRole<Guid>) GenerateAdminUser()
        {
            Guid userId = Guid.NewGuid();
            Guid roleId = Guid.NewGuid();

            PasswordHasher<ApplicationUser> hasher = new();

            ApplicationUser adminUser = new()
            {
                Id = userId,
                Name = AdminUserConstants.Name,
                UserName = AdminUserConstants.UserName,
                NormalizedUserName = AdminUserConstants.UserName.ToUpper(),
                Email = AdminUserConstants.Email,
                NormalizedEmail = AdminUserConstants.Email.ToUpper(),
                EmailConfirmed = true,
                PhoneNumber = AdminUserConstants.PhoneNumber,
                PhoneNumberConfirmed = true,
                CreatedBy = userId,
                CreatedOn = DateTime.Now,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            adminUser.PasswordHash = hasher.HashPassword(adminUser, AdminUserConstants.Password);

            ApplicationRole adminRole = new()
            {
                Id = roleId,
                Name = RoleConstants.ADMIN,
                NormalizedName = RoleConstants.ADMIN.ToUpper(),
                CreatedBy = userId,
                CreatedOn = DateTime.Now,
            };

            IdentityUserRole<Guid> adminUserRole = new()
            {
                RoleId = roleId,
                UserId = userId
            };

            return (adminUser, adminRole, adminUserRole);
        }
    }

    public class ApplicationRole : IdentityRole<Guid>
    {
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}