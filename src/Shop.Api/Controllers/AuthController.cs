using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Core.DTO.Requests;
using Shop.Core.DTO.Responses;
using Shop.Core.Interfaces.Services;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Inicia sesión a un usuario
        /// </summary>
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(200, Type = typeof(LoginResponse))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Login([FromBody]LoginRequest login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await this._authService.LoginAsync(login);

            return StatusCode(result.status, result);
        }

        /// <summary>
        /// Registra un usuario
        /// </summary>
        [HttpPost]
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public async Task<IActionResult> Register([FromBody]RegisterUserRequest user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await this._authService.SaveAsync(user);

            return StatusCode(result.status, result);
        }

        /// <summary>
        /// Cambia la contraseña del usuario
        /// </summary>
        [HttpPost]
        [Route("change_password")]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> ChangePassword([FromBody]ChangePasswordRequest changePassword)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var result = await this._authService.ChangePasswordAsync(userName, changePassword);

            return StatusCode(result.status, result);
        }
    }
}