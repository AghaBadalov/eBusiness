using EBusiness.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EBusiness.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
