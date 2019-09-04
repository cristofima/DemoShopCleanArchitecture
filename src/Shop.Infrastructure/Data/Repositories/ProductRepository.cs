using Shop.Core.Entities;
using Shop.Core.Interfaces.Repositories;

namespace Shop.Infrastructure.Data.Repositories
{
    public class ProductRepository : BaseRepository<Productos>, IProductRepository
    {
        public ProductRepository(DemoShopContext context) : base(context)
        {
        }
    }
}