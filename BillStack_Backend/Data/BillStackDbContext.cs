using BillStack_Backend.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace BillStack_Backend.Data
{
    public class BillStackDbContext : DbContext
    {
        public BillStackDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Bill> Bills { get; set; }
    }
}
