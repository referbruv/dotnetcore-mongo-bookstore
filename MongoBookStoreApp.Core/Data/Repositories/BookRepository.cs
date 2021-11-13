using MongoBookStoreApp.Contracts;
using MongoBookStoreApp.Contracts.DTO;
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

        public async Task<Book> GetBookByIdAsync(string bookId)
        {
            return await GetSingleAsync(x => x.Id == bookId);
        }

        public async Task CreateBookAsync(CreateOrUpdateBookDto model)
        {
            Book book = new Book
            {
                Name = model.Name,
                AuthorName = model.AuthorName,
                ISBN = model.ISBN,
                Description = model.Description,
                Price = model.Price
            };

            await AddAsync(book);
        }

        public async Task<Book> UpdateBookAsync(string id, CreateOrUpdateBookDto model)
        {
            Book book = new Book
            {
                Id = id,
                Name = model.Name,
                AuthorName = model.AuthorName,
                ISBN = model.ISBN,
                Description = model.Description,
                Price = model.Price
            };

            return await UpdateAsync(book);
        }

        public async Task DeleteBookAsync(string id)
        {
            await DeleteAsync(x => x.Id == id);
        }

        #region IRepository implementation

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
            var filter = Builders<Book>.Filter.Where(x => x.Id == obj.Id);
            
            var updateDefBuilder = Builders<Book>.Update;
            var updateDef = updateDefBuilder.Combine(new UpdateDefinition<Book>[]
            {
                updateDefBuilder.Set(x => x.Name, obj.Name),
                updateDefBuilder.Set(x => x.Description, obj.Description),
                updateDefBuilder.Set(x => x.AuthorName, obj.AuthorName),
                updateDefBuilder.Set(x => x.ISBN, obj.ISBN),
                updateDefBuilder.Set(x => x.Price, obj.Price)
            });
            await _books.FindOneAndUpdateAsync(filter, updateDef);

            return await _books.FindOneAndReplaceAsync(x => x.Id == obj.Id, obj);
        }

        #endregion
    }
}
