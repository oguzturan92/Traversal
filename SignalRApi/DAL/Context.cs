using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SignalRApi.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=TraversalSignalRApi;User Id=postgres;Password=Admin123;");
        }
        
        public DbSet<Visitor> Visitors { get; set; }
    }
}