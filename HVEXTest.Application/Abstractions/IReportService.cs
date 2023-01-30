using HVEXTest.Application.Models.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEXTest.Application.Abstractions
{
    public interface IReportService
    {
        Task<List<ReportDto>> GetReports();
        Task<ReportFull?> GetReportById(string id);
        Task<ReportDto> AddReport(ReportDto newReport);
        Task<ReportDto> UpdateReport(string id, ReportDto updatedReport);
        Task DeleteReport(string id);
    }
}
