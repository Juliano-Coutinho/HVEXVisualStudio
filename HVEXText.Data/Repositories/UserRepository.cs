using HVEXText.Data.Config;
using HVEXText.Data.Entities;
using HVEXText.Data.Repositories.Abstractions;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HVEXText.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserRepository(IOptions<HvexTesteDatabaseSettings> hvexTesteDatabaseSettings)
        {
            var mongoClient = new MongoClient(hvexTesteDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(hvexTesteDatabaseSettings.Value.DatabaseName);

            _userCollection = mongoDatabase.GetCollection<User>(hvexTesteDatabaseSettings.Value.HvexTesteCollectionName?.FirstOrDefault(x => x == "User"));
        }

        public async Task<List<User>> GetUsersAsync() =>
            await _userCollection.Find(_ => true).ToListAsync();

        public async Task<User?> GetUserAsync(string id) =>
            await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(User newUser) =>
            await _userCollection.InsertOneAsync(newUser);

        public async Task UpdateAsync(string id, User updatedUser)
        {
            updatedUser.UpdatedAt = DateTime.UtcNow;
            await _userCollection.ReplaceOneAsync(x => x.Id == id, updatedUser);
        }
            

        public async Task RemoveAsync(string id) =>
            await _userCollection.DeleteOneAsync(x => x.Id == id);
    }
}