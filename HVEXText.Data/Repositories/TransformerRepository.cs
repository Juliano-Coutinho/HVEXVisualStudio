using MongoDB.Driver;
using HVEXText.Data.Repositories.Abstractions;
using HVEXText.Data.Entities;
using HVEXText.Data.Config;
using Microsoft.Extensions.Options;

namespace HVEXText.Data.Repositories
{


    public class TransformerRepository : ITransformerRepository
    {
        private readonly IMongoCollection<Transformer> _transformerCollection;

        public TransformerRepository(IOptions<HvexTesteDatabaseSettings> hvexTesteDatabaseSettings)
        {
            var mongoClient = new MongoClient(hvexTesteDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(hvexTesteDatabaseSettings.Value.DatabaseName);

            _transformerCollection = mongoDatabase.GetCollection<Transformer>(hvexTesteDatabaseSettings.Value.HvexTesteCollectionName?.FirstOrDefault(x => x == "Transformer"));
        }

        public async Task<List<Transformer>> GetTransformersAsync() =>
            await _transformerCollection.Find(_ => true).ToListAsync();

        public async Task<Transformer?> GetTransformerByIdAsync(string id) =>
            await _transformerCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Transformer newTransformer) =>
            await _transformerCollection.InsertOneAsync(newTransformer);

        public async Task UpdateAsync(string id, Transformer updatedTransformer)
        {
            updatedTransformer.UpdatedAt = DateTime.UtcNow;
            await _transformerCollection.ReplaceOneAsync(x => x.Id == id, updatedTransformer);
        }
            
        public async Task RemoveAsync(string id) =>
            await _transformerCollection.DeleteOneAsync(x => x.Id == id);

        /*public async Task<bool> CheckTestByTransformer(IEnumerable<string> transformerIds, string testId)
        {
            var resp = (await _transformerCollection.(x => x.TestsId== transformer.TestsId)).FirstOrDefault();

            return resp != null;
        }*/
    }
}