using HVEXText.Data.Entities;

namespace HVEXText.Data.Repositories.Abstractions
{
    public interface ITransformerRepository
    {
        Task CreateAsync(Transformer newTransformer);
        Task<Transformer?> GetTransformerByIdAsync(string id);
        Task<List<Transformer>> GetTransformersAsync();
        Task RemoveAsync(string id);
        Task UpdateAsync(string id, Transformer updatedTransformer);
        //Task<bool> CheckTestByTransformer(Transformer transformer);
    }
}