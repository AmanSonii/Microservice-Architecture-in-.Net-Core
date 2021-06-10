
using Microsoft.EntityFrameworkCore;
using Product.Microservices.Model;
using System.Threading.Tasks;

namespace Product.Microservices.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProductData> products { get; set; }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }

    }
}
