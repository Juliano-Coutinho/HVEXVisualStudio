using HVEXText.Data.Entities;

namespace HVEXText.Data.Repositories.Abstractions
{
    public interface ITestRepository
    {
        Task Create(Test newTest);
        Task<Test?> GetTest(string id);
        Task<List<Test>> GetTests();
        Task Remove(string id);
        Task Update(string id, Test updatedTest);
    }
}