using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    /// <summary>
    /// The AppIdentityDbContext class is derived from IdentityDbContext, which provides Identity-specific features for Entity Framework Core.
    /// For the type parameter, I used the IdentityUser class, which is the built-in class used to represent users.
    /// </summary>
    public class AppIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
        : base(options) { }
    }
}