using System.Threading.Tasks;

namespace Shop.Core.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}