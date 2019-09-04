using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Shop.Core.DTO;
using Shop.Core.DTO.Responses;
using Shop.Core.Interfaces.Repositories;
using Shop.Infrastructure.Data.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UserRepository(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<bool> CheckPassword(User user, string password)
        {
            return await _userManager.CheckPasswordAsync(_mapper.Map<ApplicationUser>(user), password);
        }

        public async Task<CreateUserResponse> Create(User user, string password)
        {
            var appUser = _mapper.Map<ApplicationUser>(user);
            var identityResult = await _userManager.CreateAsync(appUser, password);
            var success = identityResult.Succeeded;

            return new CreateUserResponse(appUser.Id, success ? "Usuario creado" : "No se pudo crear el usuario", success ? 201 : 400, success ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
        }

        public async Task<User> FindByName(string userName)
        {
            var appUser = await _userManager.FindByNameAsync(userName);
            if (appUser == null)
            {
                return null;
            }

            return _mapper.Map<User>(appUser);
        }
    }
}