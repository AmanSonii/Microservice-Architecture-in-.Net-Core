using Microsoft.EntityFrameworkCore;
using Product.Microservices.Model;
using System.Threading.Tasks;

namespace Product.Microservices.Context
{
    public interface IApplicationDbContext
    {
        DbSet<ProductData> products { get; set; }

        Task<int> SaveChanges();
    }
}