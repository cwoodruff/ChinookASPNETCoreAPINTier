using Chinook.MockData.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace Chinook.UnitTest.Repository
{
    public class ArtistRepositoryTest
    {
        private readonly AlbumRepository _repo;

        public ArtistRepositoryTest()
        {
            _repo = new AlbumRepository();
        }

        [Fact]
        public async Task ArtistGetAllAsync()
        {
            // Act
            var artists = await _repo.GetAllAsync();

            // Assert
            Assert.Equal(1, artists.Count);
        }
    }
}
