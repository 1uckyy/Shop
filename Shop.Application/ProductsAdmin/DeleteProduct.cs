using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shop.Application.ProductsAdmin
{
    public class DeleteProduct
    {
        private ApplicationDbContext _context;

        public DeleteProduct(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Do(int Id)
        {
            var Product = _context.Products.FirstOrDefault(x => x.Id == Id);
            _context.Products.Remove(Product);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
