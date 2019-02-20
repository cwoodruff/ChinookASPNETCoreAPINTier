using System;
using System.Threading.Tasks;
using Chinook.Domain.Entities;
using Chinook.MockData.Dapper.Repositories;
using JetBrains.dotMemoryUnit;
using Xunit;

namespace Chinook.UnitTest.DataDapper.Repositories
{
    public class PlayListTrackRepositoryTest
    {
        private readonly PlaylistTrackRepository _repo;

        public PlayListTrackRepositoryTest()
        {
            _repo = new PlaylistTrackRepository();
        }

        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        [Fact]
        public async Task PlayListTrackGetAllAsync()
        {
            // Act
            var playListTracks = await _repo.GetAllAsync();

            // Assert
            Assert.Single(playListTracks);
        }

        [AssertTraffic(AllocatedSizeInBytes = 1000, Types = new[] {typeof(PlaylistTrack)})]
        [Fact]
        public async Task DotMemoryUnitTest()
        {
            var repo = new PlaylistTrackRepository();

            await repo.GetAllAsync();

            dotMemory.Check(memory =>
                Assert.Equal(1, memory.GetObjects(where => where.Type.Is<PlaylistTrack>()).ObjectsCount));

            GC.KeepAlive(repo); // prevent objects from GC if this is implied by test logic
        }
    }
}