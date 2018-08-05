using System;
using Chinook.MockData.Repositories;
using System.Threading.Tasks;
using Chinook.Domain.Entities;
using JetBrains.dotMemoryUnit;
using Xunit;

namespace Chinook.UnitTest.Repository
{
    public class PlayListRepositoryTest
    {
        private readonly PlaylistRepository _repo;

        public PlayListRepositoryTest()
        {
            _repo = new PlaylistRepository();
        }

        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        [Fact]
        public async Task PlayListGetAllAsync()
        {
            // Act
            var playLists = await _repo.GetAllAsync();

            // Assert
            Assert.Single(playLists);
        }

        [AssertTraffic(AllocatedSizeInBytes = 1000, Types = new[] {typeof(Playlist)})]
        [Fact]
        public async Task DotMemoryUnitTest()
        {
            var repo = new PlaylistRepository();

            await repo.GetAllAsync();

            dotMemory.Check(memory =>
                Assert.Equal(1, memory.GetObjects(where => where.Type.Is<Playlist>()).ObjectsCount));

            GC.KeepAlive(repo); // prevent objects from GC if this is implied by test logic
        }
    }
}