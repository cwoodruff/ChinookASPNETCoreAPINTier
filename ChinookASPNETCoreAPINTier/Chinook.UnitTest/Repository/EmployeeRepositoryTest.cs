using Chinook.MockData.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace Chinook.UnitTest.Repository
{
    public class EmployeeRepositoryTest
    {
        private readonly AlbumRepository _repo;

        public EmployeeRepositoryTest()
        {
            _repo = new AlbumRepository();
        }

        [Fact]
        public async Task EmployeeGetAllAsync()
        {
            // Act
            var employees = await _repo.GetAllAsync();

            // Assert
            Assert.Equal(1, employees.Count);
        }
    }
}
