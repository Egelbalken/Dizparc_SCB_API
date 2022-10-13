using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    /// <summary>
    /// Db context, will use mediator pattern Arcgeologi
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<Root>()
                .HasKey(v => v.Id);

            modelBuilder.Entity<Variable>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Root>()
                .HasOne(v => v.variables);
            */
        }

        public DbSet<Variable> variables {get;set;}

        public DbSet<Root> roots { get; set; }

    }
}