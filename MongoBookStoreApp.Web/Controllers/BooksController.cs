using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MongoBookStoreApp.Contracts.DTO;
using MongoBookStoreApp.Contracts.Entities;
using MongoBookStoreApp.Contracts.Repositories;
using MongoBookStoreApp.Contracts.Services;
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
        private readonly IValidator<CreateOrUpdateBookDto> _modelValidator;

        public BooksController(IDataService ds, IValidator<CreateOrUpdateBookDto> modelValidator)
        {
            _db = ds.Books;
            _modelValidator = modelValidator;
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
            return await _db.GetBookByIdAsync(id);
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<BaseResponseModel> PostAsync([FromBody] CreateOrUpdateBookDto model)
        {
            var result = _modelValidator.Validate(model);

            if (!result.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new BaseResponseModel
                {
                    IsSuccess = result.IsValid,
                    Errors = result.Errors.Select(x => x.ErrorMessage).ToArray()
                };
            }

            await _db.CreateBookAsync(model);

            Response.StatusCode = (int)HttpStatusCode.Created;
            return new BaseResponseModel
            {
                IsSuccess = true
            };
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public async Task<BookResponseModel> PutAsync(string id, [FromBody] CreateOrUpdateBookDto model)
        {
            var result = _modelValidator.Validate(model);

            if (!result.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new BookResponseModel
                {
                    IsSuccess = result.IsValid,
                    Errors = result.Errors.Select(x => x.ErrorMessage).ToArray()
                };
            }

            return new BookResponseModel
            {
                IsSuccess = true,
                Response = await _db.UpdateBookAsync(id, model)
            };
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(string id)
        {
            await _db.DeleteBookAsync(id);
        }
    }
}
