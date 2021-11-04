using MongoBookStoreApp.Contracts.Entities;
using MongoBookStoreApp.Contracts.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoBookStoreApp.Core.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IMongoCollection<Book> _books;

        public BookRepository(IMongoDatabase database)
        {
            _books = database.GetCollection<Book>("Books");
        }

        public async Task AddAsync(Book obj)
        {
            await _books.InsertOneAsync(obj);
        }

        public async Task DeleteAsync(Book obj)
        {
            var result = await _books.DeleteOneAsync(x => x.Id == obj.Id);
        }

        public IQueryable<Book> GetAll()
        {
            return _books.AsQueryable();
        }

        public Book GetSingle(Func<Book, bool> predicate)
        {
            return _books.FindAsync();
        }

        public Book Update(Book obj)
        {
            int i = 0;
            for (; i < _books.Count; i++)
            {
                if (_books[i].Id == obj.Id)
                {
                    _books[i] = obj;
                    break;
                }
            }
            return _books.ElementAt(i);
        }
    }
}
