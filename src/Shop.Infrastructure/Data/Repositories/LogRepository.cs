using Shop.Core.Entities;
using Shop.Core.Interfaces.Repositories;

namespace Shop.Infrastructure.Data.Repositories
{
    public class LogRepository : BaseRepository<Log>, ILogRepository
    {
        public LogRepository(DemoShopContext context) : base(context)
        {
        }
    }
}