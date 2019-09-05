using Shop.Core.DTO.Requests;
using Shop.Core.DTO.Responses;
using System.Threading.Tasks;

namespace Shop.Core.Interfaces.Services
{
    public interface IAuthService
    {
        Task<CreateUserResponse> SaveAsync(RegisterUserRequest registerUser);
        Task<BaseCRUDResponse> LoginAsync(LoginRequest loginUser);
    }
}