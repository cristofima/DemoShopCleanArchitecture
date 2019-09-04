using Shop.Core.DTO.Responses;
using Shop.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Core.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Productos>> FindAllAsync();

        Productos FindById(int id);

        Task<BaseCRUDResponse> SaveAsync(Productos product);

        Task<BaseCRUDResponse> UpdateAsync(int id, Productos product);

        Task<BaseCRUDResponse> DeleteAsync(int id);
    }
}