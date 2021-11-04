using MongoBookStoreApp.Contracts.Repositories;

namespace MongoBookStoreApp.Contracts.Services
{
    public interface IDataService
    {
        public IBookRepository Books { get; }
    }
}
