using Chinook.MockData.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace Chinook.UnitTest.Repository
{
    public class PlayListRepositoryTest
    {
        private readonly AlbumRepository _repo;

        public PlayListRepositoryTest()
        {
            _repo = new AlbumRepository();
        }

        [Fact]
        public async Task PlayListGetAllAsync()
        {
            // Act
            var playLists = await _repo.GetAllAsync();

            // Assert
            Assert.Equal(1, playLists.Count);
        }
    }
}
