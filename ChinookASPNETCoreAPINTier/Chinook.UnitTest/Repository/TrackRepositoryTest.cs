using Chinook.MockData.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace Chinook.UnitTest.Repository
{
    public class TrackRepositoryTest
    {
        private readonly AlbumRepository _repo;

        public TrackRepositoryTest()
        {
            _repo = new AlbumRepository();
        }

        [Fact]
        public async Task TrackGetAllAsync()
        {
            // Act
            var tracks = await _repo.GetAllAsync();

            // Assert
            Assert.Equal(1, tracks.Count);
        }
    }
}
