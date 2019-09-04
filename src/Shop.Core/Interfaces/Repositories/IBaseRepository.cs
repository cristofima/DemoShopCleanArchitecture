using Shop.Core.Entities;
using System.Linq;

namespace Shop.Core.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T FindById(int id);

        IQueryable<T> FindAll();

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}