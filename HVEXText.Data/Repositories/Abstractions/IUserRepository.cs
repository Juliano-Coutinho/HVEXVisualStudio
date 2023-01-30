using HVEXText.Data.Entities;

namespace HVEXText.Data.Repositories.Abstractions
{
    public interface IUserRepository
    {
        Task CreateAsync(User newUser);
        Task<User?> GetUserAsync(string id);
        Task<List<User>> GetUsersAsync();
        Task RemoveAsync(string id);
        Task UpdateAsync(string id, User updatedUser);
    }
}