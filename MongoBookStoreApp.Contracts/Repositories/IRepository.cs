using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MongoBookStoreApp.Contracts.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();

        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);

        Task AddAsync(T obj);

        Task<T> UpdateAsync(T obj);

        Task DeleteAsync(Expression<Func<T, bool>> predicate);
    }
}
