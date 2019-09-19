using Shop.Core.Entities;
using System.Threading.Tasks;

namespace Shop.Core.Interfaces.Services
{
    public interface ILogService
    {
        Task SaveAsync(Log log);
    }
}