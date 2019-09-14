using Shop.Core.DTO;
using Shop.Core.DTO.Responses;
using System.Threading.Tasks;

namespace Shop.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<CreateUserResponse> Create(User user, string password);

        Task<User> FindByName(string userName);

        Task<bool> CheckPassword(User user, string password);

        Task<BaseCRUDResponse> ChangePassword(string userName, string oldPassword, string newPassword);
    }
}