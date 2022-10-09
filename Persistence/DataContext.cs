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

        public DbSet<SCB> SCBs {get;set;}

    }
}