using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.Microservices.Context;
using Product.Microservices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Microservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IApplicationDbContext _context;
        public ProductController(IApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductData productData)
        {
            _context.products.Add(productData);
            await _context.SaveChanges();
            return Ok(productData.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _context.products.ToListAsync();
            if (products == null) return NotFound();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _context.products.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (product == null) return NotFound();
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.products.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (product == null) return NotFound();
            _context.products.Remove(product);
            await _context.SaveChanges();
            return Ok(product.Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductData productData)
        {
            var product = _context.products.Where(a => a.Id == id).FirstOrDefault();
            if (product == null) return NotFound();
            else
            {
                
                await _context.SaveChanges();
                return Ok(product.Id);
            }
        }
    }
}
