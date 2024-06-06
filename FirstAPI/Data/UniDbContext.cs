using FirstAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FirstAPI.Data
{
    public class UniDbContext:DbContext
    {
        public UniDbContext(DbContextOptions<UniDbContext> options):base(options)
        {

        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
