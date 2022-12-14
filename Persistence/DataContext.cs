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
            modelBuilder.Entity<Root>()
            .HasNoKey();
            modelBuilder.Entity<Variable>()
            .HasNoKey();
        }

        public DbSet<Variable> variables {get;set;}

        public DbSet<Root> roots { get; set; }

    }
}