using CarNow.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarNowV2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Car> Car { get; set; } = default!;

        public DbSet<Renting> Renting { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Equipment> Equipment { get; set; }

        public DbSet<Energy> Energy { get; set; }
    }
}