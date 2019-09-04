using AutoMapper;
using Shop.Core.DTO;
using Shop.Core.DTO.Requests;
using Shop.Core.DTO.Responses;
using Shop.Core.Interfaces.Repositories;
using Shop.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AuthService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CreateUserResponse> SaveAsync(RegisterUserRequest registerUser)
        {
            var appUser = await this._userRepository.FindByName(registerUser.UserName);
            if (appUser != null)
            {
                return new CreateUserResponse(string.Empty, "Usuario ya se encuentra registrado", 404);
            }
            else
            {
                appUser = new User(registerUser.Email, registerUser.UserName);
            }

            return await this._userRepository.Create(appUser, registerUser.Password);
        }
    }
}