using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Shop.Application.CreateProducts;
using Shop.Application.GetProducts;
using Shop.Application.Products;
using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _ctx;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        [BindProperty]
        public Application.CreateProducts.ProductViewModel Product { get; set; }
        public IEnumerable<Application.GetProducts.ProductViewModel> Products { get; set; }

        public void OnGet()
        {
            Products = new GetProducts(_ctx).Do();
        }

        public async Task<IActionResult> OnPost()
        {
            await new CreateProduct(_ctx).Do(Product);

            return RedirectToPage("Index");
        }
    }
}
