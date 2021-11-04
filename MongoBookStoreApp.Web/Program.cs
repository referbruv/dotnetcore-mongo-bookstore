using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoBookStoreApp.Contracts;
using MongoBookStoreApp.Core.Data;

namespace MongoBookStoreApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            //using (var scope = host.Services.CreateScope())
            //{
            //    var dbContext = scope.ServiceProvider.GetRequiredService<MongoContext>();

            //    bool isContainsBooksDatabase = false;

            //    var dbNames = dbContext.Client.ListDatabaseNames();

            //    while (dbNames.MoveNext())
            //    {
            //        if (dbNames.Current.Contains(MongoCollectionNames.Books))
            //        {
            //            isContainsBooksDatabase = true;
            //            break;
            //        }
            //    }

            //    if (!isContainsBooksDatabase)
            //    {
            //        _ = dbContext.Client.GetDatabase(MongoCollectionNames.Books);
            //        Console.WriteLine("Database Created.");
            //    }
            //}

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
