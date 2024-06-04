using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AracKiralamaPortali.API.Models;

namespace AracKiralamaPortali.Models
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cars> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}
