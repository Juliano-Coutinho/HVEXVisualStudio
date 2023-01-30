using HVEXText.Data.Config;
using HVEXText.Data.Entities;
using HVEXText.Data.Repositories.Abstractions;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HVEXText.Data.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly IMongoCollection<Test> _testCollection;

        public TestRepository(IOptions<HvexTesteDatabaseSettings> hvexTesteDatabaseSettings)
        {
            var mongoClient = new MongoClient(hvexTesteDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(hvexTesteDatabaseSettings.Value.DatabaseName);

            _testCollection = mongoDatabase.GetCollection<Test>(hvexTesteDatabaseSettings.Value.HvexTesteCollectionName?.FirstOrDefault(x => x == "Test"));
        }

        public async Task<List<Test>> GetTests() =>
            await _testCollection.Find(_ => true).ToListAsync();

        public async Task<Test?> GetTest(string id) =>
            await _testCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task Create(Test newTest) =>
            await _testCollection.InsertOneAsync(newTest);

        public async Task Update(string id, Test updatedTest)
        {
            updatedTest.UpdatedAt = DateTime.UtcNow;    
            await _testCollection.ReplaceOneAsync(x => x.Id == id, updatedTest);
        }
            

        public async Task Remove(string id) =>
            await _testCollection.DeleteOneAsync(x => x.Id == id);
    }
}