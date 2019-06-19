using System.Threading.Tasks;

namespace ShopApi.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}