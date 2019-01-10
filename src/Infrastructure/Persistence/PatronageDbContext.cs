using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class PatronageDbContext : IdentityDbContext
    {

        public PatronageDbContext(DbContextOptions<PatronageDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityRole>(e =>
            {
                e.Property(p => p.Name).HasMaxLength(255);
                e.Property(p => p.NormalizedName).HasMaxLength(255);
                e.ToTable("Roles");
            });
            builder.Entity<IdentityUser>(e =>
            {
                e.Property(p => p.UserName).HasMaxLength(255);
                e.Property(p => p.NormalizedUserName).HasMaxLength(255);
                e.Property(p => p.Email).HasMaxLength(255);
                e.Property(p => p.NormalizedEmail).HasMaxLength(255);
                e.ToTable("Users");
            });
        }
    }
}
