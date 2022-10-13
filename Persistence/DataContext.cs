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
            */
            modelBuilder.Entity<Root>()
                .HasOne(v => v.variables);

            modelBuilder.Entity<Variable>()
                .HasOne(r => r.valueTexts);

            modelBuilder.Entity<Variable>()
                .HasOne(r => r.text);
        }

        public DbSet<Variable> variables {get;set;}

        public DbSet<Root> roots { get; set; }

    }
}