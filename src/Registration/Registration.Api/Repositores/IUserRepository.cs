using Registration.Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.Api.Repositores
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(string Id);
        Task<IEnumerable<User>> GetUserByName(string name);
        Task<User> GetUserByUserName(User name);
        Task CreateUser(User User);
        Task<bool> UpdateUser(User User);
        Task<bool> DeleteUser(string id);

    }
}
