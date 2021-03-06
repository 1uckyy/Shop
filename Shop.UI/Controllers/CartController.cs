using Microsoft.AspNetCore.Mvc;
using Shop.Application.Cart;
using Shop.Database;
using System.Threading.Tasks;

namespace Shop.UI.Controllers
{
    [Route("[controller]/[action]")]
    public class CartController : Controller
    {
        private ApplicationDbContext _ctx;

        public CartController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost("{stockId}")]
        public async Task<IActionResult> AddOne(int stockId)
        {
            var request = new AddToCart.Request
            {
                StockId = stockId,
                Qty = 1
            };

            var addToCart = new AddToCart(HttpContext.Session, _ctx);

            var success = await addToCart.Do(request);

            if (success)
            {
                return Ok("Item Added to cart");
            }

            return BadRequest("Failed to add to cart");
        }

        [HttpPost("{stockId}")]
        public async Task<IActionResult> RemoveOne(int stockId)
        {
            var request = new RemoveFromCart.Request
            {
                StockId = stockId,
                Qty = 1
            };

            var addToCart = new RemoveFromCart(HttpContext.Session, _ctx);

            var success = await addToCart.Do(request);

            if (success)
            {
                return Ok("Item Added to cart");
            }

            return BadRequest("Failed to add to cart");
        }
    }
}
