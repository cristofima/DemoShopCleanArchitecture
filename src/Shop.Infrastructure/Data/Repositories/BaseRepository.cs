using Shop.Core.Entities;
using Shop.Core.Interfaces.Repositories;
using System.Linq;

namespace Shop.Infrastructure.Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DemoShopContext _context;

        public BaseRepository(DemoShopContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            this._context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this._context.Set<T>().Remove(entity);
        }

        public T FindById(int id)
        {
            return this._context.Set<T>().Find(id);
        }

        public IQueryable<T> FindAll()
        {
            return this._context.Set<T>();
        }

        public void Update(T entity)
        {
            this._context.Set<T>().Update(entity);
        }
    }
}