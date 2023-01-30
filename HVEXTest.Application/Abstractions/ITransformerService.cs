using HVEXTest.Application.Models.Transformer;
using HVEXText.Data.Entities;

namespace HVEXTest.Application.Abstractions
{
    public interface ITransformerService
    {
        Task<TransformerDto> AddTransformer(TransformerDto newTransformer);
        Task DeleteTransformer(string id);
        Task<TransformerDto?> GetTransformerById(string id);
        Task<List<TransformerDto>> GetTransformers();
        Task<TransformerDto> updateTransformer(string id, TransformerDto updatedTransformer);
    }
}