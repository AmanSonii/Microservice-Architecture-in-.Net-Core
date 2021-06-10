using Customer.Microservices.Context;
using Customer.Microservices.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Microservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IApplicationDbContext _context;
        public CustomerController(IApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerData customerData)
        {
            _context.customers.Add(customerData);
            await _context.SaveChanges();
            return Ok(customerData.CustomerID);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _context.customers.ToListAsync();
            if (customers == null) return NotFound();
            return Ok(customers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _context.customers.Where(a => a.CustomerID == id).FirstOrDefaultAsync();
            if (customer == null) return NotFound();
            return Ok(customer);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _context.customers.Where(a => a.CustomerID == id).FirstOrDefaultAsync();
            if (customer == null) return NotFound();
            _context.customers.Remove(customer);
            await _context.SaveChanges();
            return Ok(customer.CustomerID);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CustomerData customerData)
        {
            var customer = _context.customers.Where(a => a.CustomerID == id).FirstOrDefault();
            if (customer == null) return NotFound();
            else
            {
                customer.Phone = customerData.Phone;
                customer.Fax = customerData.Fax;
                await _context.SaveChanges();
                return Ok(customer.CustomerID);
            }
        }
    }
}
