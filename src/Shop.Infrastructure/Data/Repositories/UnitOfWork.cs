using Shop.Core.Interfaces;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DemoShopContext _context;

        public UnitOfWork(DemoShopContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}