using System;

namespace MongoBookStoreApp.Contracts.DTO
{
    public class BookDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ISDN { get; set; }
        public double Price { get; set; }
        public string AuthorName { get; set; }
        public string Id { get; set; }
        public DateTime AddedOn { get; set; }
    }

    public class CreateOrUpdateBookDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ISDN { get; set; }
        public double Price { get; set; }
        public string AuthorName { get; set; }
    }
}
