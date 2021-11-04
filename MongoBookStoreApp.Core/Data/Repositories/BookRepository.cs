using MongoBookStoreApp.Contracts;
using MongoBookStoreApp.Contracts.Entities;
using MongoBookStoreApp.Contracts.Repositories;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MongoBookStoreApp.Core.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IMongoCollection<Book> _books;

        public BookRepository(IMongoDatabase database)
        {
            _books = database.GetCollection<Book>(MongoCollectionNames.Books);
        }

        public async Task AddAsync(Book obj)
        {
            await _books.InsertOneAsync(obj);
        }

        public async Task DeleteAsync(Expression<Func<Book, bool>> predicate)
        {
            _ = await _books.DeleteOneAsync(predicate);
        }

        public IQueryable<Book> GetAll()
        {
            return _books.AsQueryable();
        }

        public async Task<Book> GetSingleAsync(Expression<Func<Book, bool>> predicate)
        {
            var filter = Builders<Book>.Filter.Where(predicate);
            return (await _books.FindAsync(filter)).FirstOrDefault();
        }

        public async Task<Book> UpdateAsync(Book obj)
        {
            return await _books.FindOneAndReplaceAsync(x => x.Id == obj.Id, obj);
        }
    }
}
