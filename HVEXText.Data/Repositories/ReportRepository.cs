using HVEXText.Data.Config;
using HVEXText.Data.Entities;
using HVEXText.Data.Repositories.Abstractions;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HVEXText.Data.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly IMongoCollection<Report> _reportCollection;

        public ReportRepository(IOptions<HvexTesteDatabaseSettings> hvexTesteDatabaseSettings)
        {
            var mongoClient = new MongoClient(hvexTesteDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(hvexTesteDatabaseSettings.Value.DatabaseName);

            _reportCollection = mongoDatabase.GetCollection<Report>(hvexTesteDatabaseSettings.Value.HvexTesteCollectionName?.FirstOrDefault(x => x == "Report"));
        }

        public async Task<List<Report>> GetReports() =>
            await _reportCollection.Find(_ => true).ToListAsync();

        public async Task<Report> GetReport(string id) =>
            await _reportCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task Create(Report newReport) =>
            await _reportCollection.InsertOneAsync(newReport);

        public async Task Update(string id, Report updatedReport)
        {
            updatedReport.UpdatedAt = DateTime.UtcNow;
            await _reportCollection.ReplaceOneAsync(x => x.Id == id, updatedReport);
        }

        public async Task Remove(string id) =>
            await _reportCollection.DeleteOneAsync(x => x.Id == id);
        
        public async Task<bool> CheckReportByTransformerAndTest(Report report)
        {
            var res = (await _reportCollection.FindAsync(x => x.TransformersId == report.TransformersId && x.TestId == report.TestId)).FirstOrDefault();
            return res != null;
        }


    }
}