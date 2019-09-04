using Microsoft.AspNetCore.Mvc;
using Shop.Core.DTO.Requests;
using Shop.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]RegisterUserRequest user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await this._authService.SaveAsync(user);
            if (!result.IsSuccess())
            {
                if (result.status == 409)
                {
                    return Conflict(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }

            return Ok(result);
        }
    }
}