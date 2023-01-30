using HVEXTest.Application.Abstractions;
using HVEXTest.Application.Mapping;
using HVEXTest.Application.Models.Test;
using HVEXTest.Application.Validators;
using HVEXText.Data.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEXTest.Application.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public async Task<List<TestDto>> GetTestsById()
        {
            var tests = await _testRepository.GetTests();
            var testsDto = new List<TestDto>();

            if(tests is not null) foreach (var test in tests) testsDto.Add(test.ToDto());

            return testsDto;
        }

        public async Task<TestDto?> GetTestById(string id)
        {
            var test = await _testRepository.GetTest(id);

            return test?.ToDto();
        }

        public async Task<TestDto> AddTest(TestDto newTest)
        {
            var test = newTest.ToEntity();

            var isValid = await new TestValidator().ValidateAsync(test);

            if(!isValid.IsValid) throw new ArgumentException(isValid.Errors.First().ErrorMessage);
            else
            {
                await _testRepository.Create(test);
                return test.ToDto();
            }
        }

        public async Task<TestDto> updateTest(string id, TestDto updatedTest)
        {
            var test = updatedTest.ToEntity();

            var isValid = await new TestValidator().ValidateAsync(test);

            if(!isValid.IsValid) throw new ArgumentException(isValid.Errors.First().ErrorMessage);
            else
            {
                await _testRepository.Update(id, test);
                return test.ToDto();
            }
        }

        public async Task DeleteTest(string id)
        {
            await _testRepository.Remove(id);
        }
    }
}
