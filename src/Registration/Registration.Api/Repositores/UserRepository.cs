
using Newtonsoft.Json;
using MongoDB.Driver;
using Registration.Api.Data;
using Registration.Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.Api.Repositores
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserContext _context;

        public UserRepository(IUserContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context
               .Users
               .Find(p => true)
               .ToListAsync(); ;
        }
        public async Task<User> GetUser(string Id)
        {
            return await _context.Users.Find(c => c.Id == Id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<User>> GetUserByName(string name)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.ElemMatch(p => p.Name, name);
            return await _context.Users.Find(filter).ToListAsync();
        }
        public async Task<User> GetUserByUserName(User user)
        {
            FilterDefinition<User> filter_user = Builders<User>.Filter.Eq(p => p.UserName, user.UserName);
           FilterDefinition<User> filter_pass = Builders<User>.Filter.Eq(p => p.Pasword, user.Pasword);
            FilterDefinition<User> combineFilters = Builders<User>.Filter.And(filter_user, filter_pass);
            return await _context.Users.Find(combineFilters).SingleOrDefaultAsync();
        }
        public async Task CreateUser(User User)
        {
            try
            {
                await _context.Users.InsertOneAsync(User);
            }
            catch (System.Exception ex)
            {

                throw;
            }
             
        }
        public async Task<bool> UpdateUser(User User)
        {
            var updateresult = await _context.Users.ReplaceOneAsync(filter: g => g.Id == User.Id, replacement: User);
            return updateresult.IsAcknowledged && updateresult.ModifiedCount > 0;
        }
        public async Task<bool> DeleteUser(string id)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(p => p.Id, id);
            var deleteResult = await _context.Users.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }










    }
}
