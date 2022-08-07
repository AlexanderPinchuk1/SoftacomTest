using System.Threading.Tasks;

namespace Library.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();

        Repository<T> GetRepository<T>() where T : class;
    }
}