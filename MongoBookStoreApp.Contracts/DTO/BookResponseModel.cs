using MongoBookStoreApp.Contracts.Entities;

namespace MongoBookStoreApp.Contracts.DTO
{
    public class BookResponseModel : BaseResponseModel
    {
        public Book Response { get; set; }
    }
}
