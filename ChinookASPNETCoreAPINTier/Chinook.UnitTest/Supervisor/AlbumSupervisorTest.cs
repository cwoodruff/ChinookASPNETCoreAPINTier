using System.Threading.Tasks;
using Chinook.Domain.Supervisor;
using JetBrains.dotMemoryUnit;
using Xunit;

namespace Chinook.UnitTest.Supervisor
{
    public class AlbumSupervisorTest
    {
        private readonly ChinookSupervisor _super;

        public AlbumSupervisorTest()
        {
            _super = new ChinookSupervisor();
        }

        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        [Fact]
        public async Task AlbumGetAllAsync()
        {
            // Arrange

            // Act
            var albums = await _super.GetAllAlbumAsync();

            // Assert
            Assert.Single(albums);
        }
        
        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        [Fact]
        public async Task AlbumGetOneAsync()
        {
            // Arrange
            var id = 1;

            // Act
            var album = await _super.GetAlbumByIdAsync(id);

            // Assert
            Assert.Equal(id, album.AlbumId);
        }
    }
}