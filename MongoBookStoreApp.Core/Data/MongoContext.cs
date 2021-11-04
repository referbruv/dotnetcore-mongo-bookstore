using MongoBookStoreApp.Contracts;
using MongoDB.Driver;
using System;

namespace MongoBookStoreApp.Core.Data
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(DatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoDatabase Database => _database;
    }
}
