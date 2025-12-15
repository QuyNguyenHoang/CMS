using CMS.Core.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace CMS.Infrastructure
{
    public class DataSeeder
    {
        public async Task SeedAsync(CMS_DBContext dbContext)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            var rootAdminRoleId = Guid.NewGuid();
            if (!dbContext.Roles.Any())
            {
                await dbContext.Roles.AddAsync(new AppRole()
                {
                    Id = rootAdminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    DisplayName = "Quan Tri Vien"

                });
                await dbContext.SaveChangesAsync();

            }
            if (!dbContext.Users.Any())
            {
                var userId = Guid.NewGuid();
                var user = new AppUser()
                {
                    Id = userId,
                    FirstName = "Nguyen",
                    LastName = "Hoang Quy",
                    Email = "quy@gmail.com",
                    NormalizedEmail = "QUY@GMAIL.COM",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    IsActive = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = false,
                    DateCreated = DateTime.Now,

                };
                user.PasswordHash = passwordHasher.HashPassword(user, "Admin@123");

                await dbContext.Users.AddAsync(user);
                await dbContext.UserRoles.AddAsync(new IdentityUserRole<Guid>()
                {
                    RoleId = rootAdminRoleId,
                    UserId = userId,
                });
                await dbContext.SaveChangesAsync();

            }
        }
    }
}
