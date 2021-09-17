
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Registration.Api.Entities;


namespace Registration.Api.Data
{
    public class UserContext : IUserContext
    {

        public UserContext(IConfiguration configuration)
        {
            var clint = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionSetting"));
            var database = clint.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Users = database.GetCollection<User>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));

        }
        public IMongoCollection<User> Users { get; }


    }
}
