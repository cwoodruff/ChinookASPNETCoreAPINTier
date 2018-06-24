using Chinook.MockData.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace Chinook.UnitTest.Repository
{
    public class MediaTypeRepositoryTest
    {
        private readonly AlbumRepository _repo;

        public MediaTypeRepositoryTest()
        {
            _repo = new AlbumRepository();
        }

        [Fact]
        public async Task MediaTypeGetAllAsync()
        {
            // Act
            var mediaTypes = await _repo.GetAllAsync();

            // Assert
            Assert.Equal(1, mediaTypes.Count);
        }
    }
}
