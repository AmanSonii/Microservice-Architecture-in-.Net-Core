using Customer.Microservices.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Customer.Microservices.Context
{
    public interface IApplicationDbContext
    {
        DbSet<CustomerData> customers { get; set; }
        Task<int> SaveChanges();
    }
}