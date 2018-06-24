using Chinook.MockData.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace Chinook.UnitTest.Repository
{
    public class CustomerRepositoryTest
    {
        private readonly AlbumRepository _repo;

        public CustomerRepositoryTest()
        {
            _repo = new AlbumRepository();
        }

        [Fact]
        public async Task CustomerGetAllAsync()
        {
            // Act
            var customers = await _repo.GetAllAsync();

            // Assert
            Assert.Equal(1, customers.Count);
        }
    }
}
