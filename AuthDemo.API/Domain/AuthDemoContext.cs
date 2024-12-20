using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthDemo.Domain;

public class AuthDemoContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
  public AuthDemoContext(DbContextOptions<AuthDemoContext> options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    (ApplicationUser adminUser, ApplicationRole adminRole, IdentityUserRole<Guid> adminUserRole) = ApplicationUser.GenerateAdminUser();

    builder.Entity<ApplicationUser>()
    .HasData(adminUser);

    builder.Entity<ApplicationRole>()
    .HasData(adminRole);

    builder.Entity<IdentityUserRole<Guid>>()
    .HasData(adminUserRole);

    base.OnModelCreating(builder);
  }
}