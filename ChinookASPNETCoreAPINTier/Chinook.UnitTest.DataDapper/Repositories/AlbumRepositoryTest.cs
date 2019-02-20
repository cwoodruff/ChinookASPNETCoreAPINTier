using System;
using System.Threading.Tasks;
using Chinook.Domain.Entities;
using Chinook.MockData.Dapper.Repositories;
using JetBrains.dotMemoryUnit;
using Xunit;

namespace Chinook.UnitTest.DataDapper.Repositories
{
    public class AlbumRepositoryTest
    {
        private readonly AlbumRepository _repo;

        public AlbumRepositoryTest()
        {
            _repo = new AlbumRepository();
        }

        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        [Fact]
        public async Task AlbumGetAllAsync()
        {
            // Arrange

            // Act
            var albums = await _repo.GetAllAsync();

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
            var album = await _repo.GetByIdAsync(id);

            // Assert
            Assert.Equal(id, album.AlbumId);
        }

        [AssertTraffic(AllocatedSizeInBytes = 1000, Types = new[] {typeof(Album)})]
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