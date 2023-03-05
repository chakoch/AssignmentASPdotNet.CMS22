using AssignmentASPdotNet.CMS22.Models.Entities;
using AssignmentASPdotNet.CMS22.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AssignmentASPdotNet.CMS22.Contexts
{
    public class IdentityContext : IdentityDbContext<AppUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }

        public DbSet<UserProfileEntity> UserProfileEntities { get; set; }

    }
}
