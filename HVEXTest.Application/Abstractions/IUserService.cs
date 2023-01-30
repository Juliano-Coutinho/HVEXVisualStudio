using HVEXTest.Application.Models.User;
using HVEXText.Data.Entities;

namespace HVEXTest.Application.Abstractions
{
    public interface IUserService
    {
        Task<UserDto> AddUser(UserDto newUser);
        Task DeleteUser(string id);
        Task<UserDto?> GetUserById(string id);
        Task<List<UserDto>> GetUsersById();
        Task<UserDto> UpdatedUser(string id, UserDto updatedUser);
    }
}