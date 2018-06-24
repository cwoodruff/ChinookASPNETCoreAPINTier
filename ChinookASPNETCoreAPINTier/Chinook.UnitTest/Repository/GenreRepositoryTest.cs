using Chinook.MockData.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace Chinook.UnitTest.Repository
{
    public class GenreRepositoryTest
    {
        private readonly AlbumRepository _repo;

        public GenreRepositoryTest()
        {
            _repo = new AlbumRepository();
        }

        [Fact]
        public async Task GenreGetAllAsync()
        {
            // Act
            var genres = await _repo.GetAllAsync();

            // Assert
            Assert.Equal(1, genres.Count);
        }
    }
}
