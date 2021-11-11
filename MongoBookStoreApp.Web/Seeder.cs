using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoBookStoreApp.Contracts.Entities;
using MongoBookStoreApp.Contracts.Services;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MongoBookStoreApp.Web
{
    public static class Seeder
    {
        public static async Task SeedDatabaseAsync(IServiceScope scope)
        {
            var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
            var db = scope.ServiceProvider.GetRequiredService<IDataService>();

            if (db.Books.GetAll().Count() == 0)
            {
                // Path.Combine(env.ContentRootPath, @"\Assets\Data\books.json")
                var booksJson = await File.ReadAllTextAsync(Path.Combine(env.WebRootPath, @"assets/data/books.json"));

                var books = JsonSerializer.Deserialize<Book[]>(booksJson);

                foreach (var book in books)
                {
                    await db.Books.AddAsync(book);
                }

                Console.WriteLine($"Records in DB: {db.Books.GetAll().Count()}");
            }
        }
    }
}
