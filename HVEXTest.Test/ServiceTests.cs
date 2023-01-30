using HVEXTest.Application.Services;
using HVEXText.Data.Entities;
using HVEXText.Data.Repositories;
using HVEXText.Data.Repositories.Abstractions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HVEXTest.Test
{
    public class ServiceTests
    {
        
        private readonly Mock<IUserRepository> _userRepository;
        private readonly UserService _userService;

        public ServiceTests()
        {
            _userRepository = new Mock<IUserRepository>();
            _userService = new UserService(_userRepository.Object);
        }

        [Fact]
        public async Task Get_User_By_Id_Success()
        {
            string userId = "IdTest1";
            
            _userRepository.Setup(x => x.GetUserAsync(It.IsAny<string>()))
                .ReturnsAsync(new User { Id = userId, CreatedAt = DateTime.UtcNow, Email = "email@test.com" });

            var user = await _userService.GetUserById(userId);

            Assert.NotNull(user);
            Assert.Equal(user.Id, userId);
        }

        [Fact]
        public async Task Get_User_By_Id_Fail()
        {
            string userId = "IdTest1";

            _userRepository.Setup(x => x.GetUserAsync(userId))
                .ReturnsAsync(new User { Id = userId, CreatedAt = DateTime.UtcNow, Email = "email@test.com" });

            var user = await _userService.GetUserById("IdTest2");

            Assert.Null(user);
        }
    }
}
