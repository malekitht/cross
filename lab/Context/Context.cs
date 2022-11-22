using lab.Models;
using Microsoft.EntityFrameworkCore;

namespace lab.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public Context()
        {

        }
        public DbSet<lab3> LegoSet { get; set; }
    }
}
