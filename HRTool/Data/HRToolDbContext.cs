using HRTool.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRTool.Data
{
    public class HRToolDbContext(DbContextOptions<HRToolDbContext> hrToolDbContext) : DbContext(hrToolDbContext)
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Vacation> Vacations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Vacations)
                .WithOne(v => v.User)
                .HasForeignKey(v => v.UserId);

        }

    }
}
