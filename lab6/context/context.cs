using laba34.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace laba34.context
{
    public class context: DbContext
    {
        public context(DbContextOptions<context> options) : base(options)
        {
            Database.EnsureCreated();
        }
        options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
       
        public DbSet<laba3> LegoSet { get; set; }
    }
}
