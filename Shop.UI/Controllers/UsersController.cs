using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Cart;
using Shop.Application.UsersAdmin;
using Shop.Database;
using System.Threading.Tasks;

namespace Shop.UI.Controllers
{
    [Route("[controller]")]
    [Authorize(Policy = "Admin")]
    public class UsersController : Controller
    {
        private CreateUser _createUser;

        public UsersController(CreateUser createUser)
        {
            _createUser = createUser;
        }

        public async Task<IActionResult> CreateUser([FromBody] CreateUser.Request request)
        {
            await _createUser.Do(request);

            return Ok();
        }
    }
}
