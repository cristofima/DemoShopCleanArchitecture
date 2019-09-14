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

        public async Task<BaseCRUDResponse> ChangePasswordAsync(string userName, ChangePasswordRequest changePassword)
        {
            var result = await this._userRepository.ChangePassword(userName, changePassword.OldPassword, changePassword.NewPassword);
            return result;
        }

        public async Task<BaseCRUDResponse> LoginAsync(LoginRequest loginUser)
        {
            var appUser = await this._userRepository.FindByName(loginUser.UserName);
            if (appUser == null)
            {
                return new CreateUserResponse($"Usuario '{loginUser.UserName}' no se encuentra registrado", 404);
            }
            else
            {
                var checkPassword = await this._userRepository.CheckPassword(appUser, loginUser.Password);
                if (checkPassword)
                {
                    var tokenString = this._jwtFactory.GenerateEncodedToken(appUser.UserName, appUser.Email);
                    var expireDate = this._jwtFactory.GetExpireDate(tokenString);

                    return new LoginResponse(tokenString, "Login exitoso", 200, expireDate);
                }

                return new ErrorCRUDResponse("Clave incorrecta", 400);
            }
        }

        public async Task<CreateUserResponse> SaveAsync(RegisterUserRequest registerUser)
        {
            var appUser = await this._userRepository.FindByName(registerUser.UserName);
            if (appUser != null)
            {
                return new CreateUserResponse("Usuario ya se encuentra registrado", 409);
            }
            else
            {
                appUser = new User(registerUser.Email, registerUser.UserName);
            }

            return await this._userRepository.Create(appUser, registerUser.Password);
        }
    }
}