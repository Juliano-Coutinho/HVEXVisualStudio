using HVEXTest.Application.Abstractions;
using HVEXTest.Application.Models.Report;
using Microsoft.AspNetCore.Mvc;

namespace HVEXTest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<List<ReportDto>> GetReports() =>
            await _reportService.GetReports();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<ReportFull>> GetReport(string id)
        {
            var report = await _reportService.GetReportById(id);

            if (report is null)
            {
                return NotFound();
            }

            return report;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ReportDto newReport)
        {
            var response = await _reportService.AddReport(newReport);

            return CreatedAtAction(nameof(GetReport), new { id = response.Id }, response);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, ReportDto updatedReport)
        {
            var report = await _reportService.GetReportById(id);

            if (report is null)
            {
                return NotFound();
            }

            updatedReport.Id = report.Id;

            await _reportService.UpdateReport(id, updatedReport);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delte(string id)
        {
            var report = await _reportService.GetReportById(id);

            if (report is null)
            {
                return NotFound();
            }

            await _reportService.DeleteReport(id);

            return NoContent();
        }
    }
}