using System;
using System.Linq;

namespace MongoBookStoreApp.Contracts.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();

        T GetSingle(Func<T, bool> predicate);

        T AddAsync(T obj);

        T Update(T obj);

        void DeleteAsync(T obj);
    }
}
