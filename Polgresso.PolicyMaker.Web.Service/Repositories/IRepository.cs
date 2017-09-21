using Polgresso.Entities;
using System.Threading.Tasks;

namespace Polgresso.PolicyMaker.Web.Service.Repositories
{
    public interface IRepository<T>
    {
        Task<PagedList<T>> GetAll(int? page);

        Task AddAsync(T entity);

        Task<T> GetSingleAsync(int id);

        Task DeleteAsync(T entity);

        Task UpdateAsync(T entity);

        Task<bool> SaveAsync();
    }
}