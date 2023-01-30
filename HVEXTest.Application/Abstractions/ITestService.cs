using HVEXTest.Application.Models.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEXTest.Application.Abstractions
{
    public interface ITestService
    {
        Task<TestDto> AddTest(TestDto newTest);
        Task DeleteTest(string id);
        Task<TestDto?> GetTestById(string id);
        Task<List<TestDto>> GetTestsById();
        Task<TestDto> updateTest(string id, TestDto updatedTest);
    }
}
