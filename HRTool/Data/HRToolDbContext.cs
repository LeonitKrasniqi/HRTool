using HRTool.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRTool.Data
{
    public class HRToolDbContext(DbContextOptions<HRToolDbContext> hrToolDbContext) : DbContext(hrToolDbContext)
    {

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

        }

    }
}
