using HVEXTest.Application.Abstractions;
using HVEXTest.Application.Mapping;
using HVEXTest.Application.Models.Report;
using HVEXTest.Application.Validators;
using HVEXText.Data.Entities;
using HVEXText.Data.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEXTest.Application.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly ITestRepository _testRepository;
        private readonly ITransformerRepository _transformerRepository;

        public ReportService(IReportRepository reportRepository, ITestRepository testRepository, ITransformerRepository transformerRepository)
        {
            _reportRepository = reportRepository;
            _testRepository = testRepository;
            _transformerRepository = transformerRepository;
        }

        public async Task<List<ReportDto>> GetReports()
        {
            var reports = await _reportRepository.GetReports();
            var reportsDto = new List<ReportDto>();

            if (reports is not null) foreach (var report in reports) reportsDto.Add(report.ToDto());

            return reportsDto;
        }

        public async Task<ReportFull?> GetReportById(string id)
        {
            var report = await _reportRepository.GetReport(id);

            var reportFull = report.ToFull();

            var teste = await _testRepository.GetTest(report.TestId);

            if (teste is not null) reportFull.Test = teste.ToDto();
            
            foreach(var transformerrId in report.TransformersId)
            {
                var transformer = await _transformerRepository.GetTransformerByIdAsync(transformerrId);
                if (transformer is not null) reportFull.Transformers.Add(transformer.ToDto());
            }
            
            return reportFull;
        }

        public async Task<ReportDto> AddReport(ReportDto newReport)
        {
            var report = newReport.ToEntity();

            var isValid = await new ReportValidator().ValidateAsync(report);

            if (!isValid.IsValid) throw new ArgumentException(isValid.Errors.First().ErrorMessage);

            if (await _reportRepository.CheckReportByTransformerAndTest(report))
                throw new ArgumentException("Um ou mais transformadores ja tem um relatorio com o teste informado");

           // if (await _transformerRepository.CheckTestByTransformer(report))

            foreach (var transformerId in newReport.TransformersId!)
            {
                var transformer = await _transformerRepository.GetTransformerByIdAsync(transformerId);

                if (transformer is null) throw new ArgumentNullException("Algum Transformador informado não foi encontrado");
            }

            var test = await _testRepository.GetTest(newReport.TestId!);

            if(test is null) throw new ArgumentNullException("O ensaio informado não foi encontrado");

            await _reportRepository.Create(report);

            return report.ToDto();

        }

        public async Task<ReportDto> UpdateReport(string id, ReportDto updatedReport)
        {
            var report = updatedReport.ToEntity();

            var isValid = await new ReportValidator().ValidateAsync(report);

            if (!isValid.IsValid) throw new ArgumentException(isValid.Errors.First().ErrorMessage);

            foreach (var transformerId in updatedReport.TransformersId!)
            {
                var transformer = await _transformerRepository.GetTransformerByIdAsync(transformerId);
                if (transformer is null) throw new ArgumentNullException("Algum Transformador informado não foi encontrado");
            }

            var test = await _testRepository.GetTest(updatedReport.TestId!);

            if (test is null) throw new ArgumentNullException("O ensaio informado não foi encontrado");

            await _reportRepository.Update(id, report);

            return report.ToDto();
        }

        public async Task DeleteReport(string id)
        {
            await _reportRepository.Remove(id);
        }
    }
}
