using HVEXTest.Application.Abstractions;
using HVEXTest.Application.Models.Test;
using Microsoft.AspNetCore.Mvc;

namespace HVEXTest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        public async Task<List<TestDto>> GetTests() =>
            await _testService.GetTestsById();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<TestDto>> GetTest(string id)
        {
            var test = await _testService.GetTestById(id);

            if (test is null)
            {
                return NotFound();
            }

            return test;
        }

        [HttpPost]
        public async Task<IActionResult> Post(TestDto newTest)
        {
            var response = await _testService.AddTest(newTest);    

            return CreatedAtAction(nameof(GetTest), new { id = response.Id }, response);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, TestDto updatedTest)
        {
            var test = await _testService.GetTestById(id);

            if (test is null)
            {
                return NotFound();
            }

            updatedTest.Id = test.Id;

            await _testService.updateTest(id, updatedTest);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var test = _testService.GetTestById(id);

            if (test is null)
            {
                return NotFound();
            }

            await _testService.DeleteTest(id);

            return NoContent();
        }
    }
}