using HVEXText.Data.Config;
using HVEXText.Data.Entities;
using HVEXText.Data.Repositories;
using HVEXText.Data.Repositories.Abstractions;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using System.Linq.Expressions;
using Xunit;

namespace HVEXTest.Test
{
    public class DataTesting
    {
        private readonly Mock<IMongoCollection<User>> _userCollection;

        private readonly Mock<IUserRepository> _userRepository;

        private readonly UserRepository _userRepo;

        private readonly IOptions<HvexTesteDatabaseSettings> hvexTesteDatabaseSettings;

        public DataTesting()
        {
            _userCollection = new Mock<IMongoCollection<User>>();
            _userRepository = new Mock<IUserRepository>();
            hvexTesteDatabaseSettings = Options.Create<HvexTesteDatabaseSettings>(new HvexTesteDatabaseSettings {
                ConnectionString = "mongodb://localhost:27017",
                DatabaseName = "HvexTesteDb",
                HvexTesteCollectionName = new string[] {"User", "Transformer", "Test", "Report"}
            });
            _userRepo = new UserRepository(hvexTesteDatabaseSettings);
        }

        [Fact]
        public async Task GetUserById()
        {
            //public async Task<User?> GetUserAsync(string id) =>
            //await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            //_userCollection.Setup(x => x.Find(It.IsAny<Expression<Func<User,bool>>>())).ReturnsAsync(new User { Id = "63d6c89ea67aa0dff4271dad" });
            //_userRepository.Setup(x => x.GetUserAsync(It.IsAny<string>())).ReturnsAsync(new User { Id = "63d6c89ea67aa0dff4271dad" });

            var res = await _userRepo.GetUserAsync("63d6c89ea67aa0dff4271dad");
        }
    }
}