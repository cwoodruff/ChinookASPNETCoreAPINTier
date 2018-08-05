using System;
using Chinook.MockData.Repositories;
using System.Threading.Tasks;
using Chinook.Domain.Entities;
using JetBrains.dotMemoryUnit;
using Xunit;

namespace Chinook.UnitTest.Repository
{
    public class TrackRepositoryTest
    {
        private readonly TrackRepository _repo;

        public TrackRepositoryTest()
        {
            _repo = new TrackRepository();
        }

        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        [Fact]
        public async Task TrackGetAllAsync()
        {
            // Act
            var tracks = await _repo.GetAllAsync();

            // Assert
            Assert.Single(tracks);
        }

        [AssertTraffic(AllocatedSizeInBytes = 1000, Types = new[] {typeof(Track)})]
        [Fact]
        public async Task DotMemoryUnitTest()
        {
            var repo = new TrackRepository();

            await repo.GetAllAsync();

            dotMemory.Check(memory =>
                Assert.Equal(1, memory.GetObjects(where => where.Type.Is<Track>()).ObjectsCount));

            GC.KeepAlive(repo); // prevent objects from GC if this is implied by test logic
        }
    }
}