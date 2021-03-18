using Microsoft.EntityFrameworkCore;
using PartService.DataLayer.Models;

namespace PartService.DataLayer.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        public DbSet<Part> Part { get; set; }
        public DbSet<PartType> PartType { get; set; }
    }
}
