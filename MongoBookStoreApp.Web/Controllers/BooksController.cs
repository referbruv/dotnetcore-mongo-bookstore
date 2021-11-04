using Microsoft.AspNetCore.Mvc;
using MongoBookStoreApp.Contracts.DTO;
using MongoBookStoreApp.Contracts.Entities;
using MongoBookStoreApp.Contracts.Repositories;
using MongoBookStoreApp.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MongoBookStoreApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _db;

        public BooksController(IDataService ds)
        {
            _db = ds.Books;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _db.GetAll();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<Book> GetAsync(string id)
        {
            return await _db.GetSingleAsync(x => x.Id == id);
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task PostAsync([FromBody] CreateOrUpdateBookDto model)
        {
            Book book = new Book
            {
                Name = model.Name,
                AuthorName = model.AuthorName,
                ISDN = model.ISDN,
                Description = model.Description,
                Price = model.Price,
                AddedOn = DateTime.Now
            };

            await _db.AddAsync(book);

            Response.StatusCode = (int)HttpStatusCode.Created;
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public async Task<Book> PutAsync(string id, [FromBody] CreateOrUpdateBookDto model)
        {
            Book book = new Book
            {
                Id = id,
                Name = model.Name,
                AuthorName = model.AuthorName,
                ISDN = model.ISDN,
                Description = model.Description,
                Price = model.Price,
                AddedOn = DateTime.Now
            };

            return await _db.UpdateAsync(book);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(string id)
        {
            await _db.DeleteAsync(x => x.Id == id);
        }
    }
}
