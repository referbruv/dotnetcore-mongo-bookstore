namespace MongoBookStoreApp.Contracts.DTO
{
    public class BaseResponseModel
    {
        public bool IsSuccess { get; set; }
        public string[] Errors { get; set; }
    }
}
