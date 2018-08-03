using System;
using Chinook.MockData.Repositories;
using System.Threading.Tasks;
using Chinook.Domain.Entities;
using JetBrains.dotMemoryUnit;
using Xunit;

namespace Chinook.UnitTest.Repository
{
    public class AlbumRepositoryTest
    {
        private readonly AlbumRepository _repo;

        public AlbumRepositoryTest()
        {
            _repo = new AlbumRepository();
        }

        [DotMemoryUnitAttribute(FailIfRunWithoutSupport = false)]
        [Fact]
        public async Task AlbumGetAllAsync()
        {
            // Arrange
            
            // Act
            var albums = await _repo.GetAllAsync();

            // Assert
            Assert.Single(albums);
        }
        
        [DotMemoryUnitAttribute(FailIfRunWithoutSupport = false)]
        [Fact]
        public async Task AlbumGetOneAsync()
        {
            // Arrange
            var number = 1;
            
            // Act
            var album = await _repo.GetByIdAsync(1);

            // Assert
            Assert.Equal(1, album.AlbumId);
        }
        
        [AssertTraffic(AllocatedSizeInBytes = 1000, Types = new[] { typeof(Album) })]
        [Fact]
        public async Task DotMemoryUnitTest()
        {
            var repo = new AlbumRepository();

            await repo.GetAllAsync();

            dotMemory.Check(memory =>
                Assert.Equal(1, memory.GetObjects(where => where.Type.Is<Album>()).ObjectsCount));

            GC.KeepAlive(repo); // prevent objects from GC if this is implied by test logic
        }
    }
}
