using HVEXTest.Application.Abstractions;
using HVEXTest.Application.Mapping;
using HVEXTest.Application.Models.User;
using HVEXTest.Application.Validators;
using HVEXText.Data.Entities;
using HVEXText.Data.Repositories.Abstractions;

namespace HVEXTest.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> GetUsersById()
        {
            var users = await _userRepository.GetUsersAsync();
            var usersDto = new List<UserDto>();

            if(users is not null)
            {
                foreach (var user in users)
                {
                    usersDto.Add(user.ToDto());
                }
            }
            
            return usersDto;
        }

        public async Task<UserDto?> GetUserById(string id)
        {
            var user = await _userRepository.GetUserAsync(id);

            return user?.ToDto();
        }

        public async Task<UserDto> AddUser(UserDto newUser)
        {
            var user = newUser.ToEntity();

            var isValid = await new UserValidator().ValidateAsync(user);

            if (!isValid.IsValid)
            {
                throw new ArgumentException(isValid.Errors.First().ErrorMessage);
            }
            else
            {
                await _userRepository.CreateAsync(user);
                return user.ToDto();
            }
        }

        public async Task<UserDto> UpdatedUser(string id, UserDto updatedUser)
        {
            var user = updatedUser.ToEntity();

            var isValid = await new UserValidator().ValidateAsync(user);

            if(!isValid.IsValid)
            {
                throw new ArgumentException(isValid.Errors.First().ErrorMessage);
            }
            else
            {
                await _userRepository.UpdateAsync(id, user); 
                return user.ToDto();
            }

        }

        public async Task DeleteUser(string id)
        {
            await _userRepository.RemoveAsync(id);
        }
    }
}