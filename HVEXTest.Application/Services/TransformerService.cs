using HVEXTest.Application.Abstractions;
using HVEXTest.Application.Mapping;
using HVEXTest.Application.Models.Transformer;
using HVEXTest.Application.Validators;
using HVEXText.Data.Entities;
using HVEXText.Data.Repositories.Abstractions;

namespace HVEXTest.Application.Services
{
    public class TransformerService : ITransformerService
    {
        private readonly ITransformerRepository _transformerRepository;
        private readonly ITestRepository _testeRepository;
        private readonly IReportRepository _reportRepository;

        public TransformerService(ITransformerRepository transformerRepository, ITestRepository testeRepository, IReportRepository reportRepository)
        {
            _transformerRepository = transformerRepository;
            _testeRepository = testeRepository;
            _reportRepository = reportRepository;
        }

        public async Task<List<TransformerDto>> GetTransformers()
        {
            var transformers = await _transformerRepository.GetTransformersAsync();
            var transformersDto = new List<TransformerDto>();
            
            if(transformers is not null)
            {
                foreach (var transformer in transformers)
                {
                    transformersDto.Add(transformer.ToDto());
                }
            }

            return transformersDto;
        }

        public async Task<TransformerDto?> GetTransformerById(string id)
        {
            var transformer = await _transformerRepository.GetTransformerByIdAsync(id);

            return transformer?.ToDto();
        }

        public async Task<TransformerDto> AddTransformer(TransformerDto newTransformer)
        {
            var transformer = newTransformer.ToEntity();

            var isValid = await new TransformerValidator().ValidateAsync(transformer);

            if (!isValid.IsValid) throw new ArgumentException(isValid.Errors.First().ErrorMessage);

            if (newTransformer.TestsId?.Count() > 0)
            {
                foreach (var testId in newTransformer.TestsId!)
                {
                    var test = _testeRepository.GetTest(testId);
                    if (test.IsFaulted) throw new ArgumentNullException("O Ensaio de id: " + testId + " não foi encontrado");
                }
            }

            if (newTransformer.ReportsId?.Count() > 0)
            {
                foreach (var reportId in newTransformer.ReportsId)
                {
                    var report = _reportRepository.GetReport(reportId);
                    if (report.IsFaulted) throw new ArgumentNullException("O Relatório de id: " + reportId + " não foi encontrado");
                }
            }

            await _transformerRepository.CreateAsync(transformer);
            return transformer.ToDto();
        }

        public async Task<TransformerDto> updateTransformer(string id, TransformerDto updatedTransformer)
        {
            var transformer = updatedTransformer.ToEntity();

            var isValid = await new TransformerValidator().ValidateAsync(transformer);

            if (!isValid.IsValid) throw new ArgumentException(isValid.Errors.First().ErrorMessage);

            if(updatedTransformer.TestsId?.Count() > 0)
            {
                foreach (var testId in updatedTransformer.TestsId!)
                {
                    var test = _testeRepository.GetTest(testId);
                    if (test.IsFaulted) throw new ArgumentNullException("O Ensaio de id: "+ testId +" não foi encontrado");
                }
            }

            if(updatedTransformer.ReportsId?.Count() > 0)
            {
                foreach (var reportId in updatedTransformer.ReportsId)
                {
                    var report = _reportRepository.GetReport(reportId);
                    if (report.IsFaulted) throw new ArgumentNullException("O Relatório de id: "+ reportId +" não foi encontrado");
                }
            }

            await _transformerRepository.UpdateAsync(id, transformer);
            return transformer.ToDto();
        }

        public async Task DeleteTransformer(string id)
        {
            await _transformerRepository.RemoveAsync(id);
        }
    }
}