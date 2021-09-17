
using MongoDB.Driver;
using Registration.Api.Entities;


namespace Registration.Api.Data
{
    public interface IUserContext
    {
        IMongoCollection<User> Users { get; }
    }
}
