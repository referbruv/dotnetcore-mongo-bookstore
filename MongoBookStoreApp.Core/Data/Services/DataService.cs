using MongoBookStoreApp.Contracts.Repositories;
using MongoBookStoreApp.Contracts.Services;
using MongoBookStoreApp.Core.Data.Repositories;

namespace MongoBookStoreApp.Core.Data.Services
{
    public class DataService : IDataService
    {
        private readonly MongoContext _dbContext;

        public DataService(MongoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IBookRepository Books => new BookRepository(_dbContext.Database);
    }
}
