using MongoBookStoreApp.Contracts.DTO;
using MongoBookStoreApp.Contracts.Entities;
using System.Threading.Tasks;

namespace MongoBookStoreApp.Contracts.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<Book> GetBookByIdAsync(string bookId);

        Task CreateBookAsync(CreateOrUpdateBookDto model);

        Task<Book> UpdateBookAsync(string id, CreateOrUpdateBookDto model);
        Task DeleteBookAsync(string id);
    }
}
