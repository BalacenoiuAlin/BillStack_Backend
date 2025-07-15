using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BillStack_Backend.Data
{
    public class BillStackAuthDbContext : IdentityDbContext
    {
        public BillStackAuthDbContext(DbContextOptions<BillStackAuthDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminId = "4a127129-679f-4cbf-a173-7828941e02fa";
            var userId = "c8ad7f29-a628-4f71-a4a2-d0a98a2672be";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = adminId,
                    ConcurrencyStamp = "Admin",
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper(),
                },

                new IdentityRole
                {
                    Id = userId,
                    ConcurrencyStamp = "User",
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
