using Microsoft.AspNetCore.Identity;
using Shop.Core.DTO;
using Shop.Core.DTO.Responses;
using Shop.Core.Interfaces.Repositories;
using Shop.Infrastructure.Data.Identity;
using Shop.Infrastructure.Helpers;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> CheckPassword(User user, string password)
        {
            return await _userManager.CheckPasswordAsync(Casting.UserToApplicationUser(user), password);
        }

        public async Task<CreateUserResponse> Create(User user, string password)
        {
            var appUser = Casting.UserToApplicationUser(user);

            var identityResult = await _userManager.CreateAsync(appUser, password);
            var success = identityResult.Succeeded;

            return new CreateUserResponse(success ? "Usuario creado" : $"No se pudo crear el usuario {user.UserName}", success ? 201 : 400, success ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
        }

        public async Task<User> FindByName(string userName)
        {
            var appUser = await _userManager.FindByNameAsync(userName);

            if (appUser == null)
            {
                return null;
            }

            return Casting.ApplicationUserToUser(appUser);
        }

        public async Task<BaseCRUDResponse> ChangePassword(string userName, string oldPassword, string newPassword)
        {
            var appUser = await _userManager.FindByNameAsync(userName);

            if (appUser == null)
            {
                return new ErrorCRUDResponse($"Usuario '{userName}' no se encuentra registrado", 404);
            }

            var result = await _userManager.ChangePasswordAsync(appUser, oldPassword, newPassword);
            if (result.Succeeded)
            {
                return new SuccessCRUDResponse("Contraseña cambiada", null);
            }

            return new ErrorCRUDResponse("Error al cambiar la contraseña", 400, result.Errors.Select(x => new Error(x.Code, x.Description)));
        }
    }
}