using HVEXText.Data.Entities;

namespace HVEXText.Data.Repositories.Abstractions
{
    public interface IReportRepository
    {
        Task Create(Report newReport);
        Task<Report> GetReport(string id);
        Task<List<Report>> GetReports();
        Task Remove(string id);
        Task Update(string id, Report updatedReport);
        Task<bool> CheckReportByTransformerAndTest(Report report);

    }
}