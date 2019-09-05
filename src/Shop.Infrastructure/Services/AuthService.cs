using Shop.Core.DTO;
using Shop.Core.DTO.Requests;
using Shop.Core.DTO.Responses;
using Shop.Core.Interfaces;
using Shop.Core.Interfaces.Repositories;
using Shop.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtFactory _jwtFactory;

        public AuthService(IUserRepository userRepository, IJwtFactory jwtFactory)
        {
            _userRepository = userRepository;
            _jwtFactory = jwtFactory;
        }

        public async Task<BaseCRUDResponse> LoginAsync(LoginRequest loginUser)
        {
            var appUser = await this._userRepository.FindByName(loginUser.UserName);
            if (appUser == null)
            {
                return new CreateUserResponse(string.Empty, "Usuario no se encuentra registrado", 404);
            }
            else
            {
                var tokenString = this._jwtFactory.GenerateEncodedToken(appUser.UserName, appUser.Email);
                return new LoginResponse(tokenString, "Login exitoso", 200);
            }
        }

        public async Task<CreateUserResponse> SaveAsync(RegisterUserRequest registerUser)
        {
            var appUser = await this._userRepository.FindByName(registerUser.UserName);
            if (appUser != null)
            {
                return new CreateUserResponse(string.Empty, "Usuario ya se encuentra registrado", 409);
            }
            else
            {
                appUser = new User(registerUser.Email, registerUser.UserName);
            }

            return await this._userRepository.Create(appUser, registerUser.Password);
        }
    }
}