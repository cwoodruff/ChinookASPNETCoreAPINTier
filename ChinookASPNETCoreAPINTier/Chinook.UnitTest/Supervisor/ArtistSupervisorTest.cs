using System;
using Chinook.MockData.Repositories;
using System.Threading.Tasks;
using Chinook.Domain.Entities;
using Chinook.Domain.Supervisor;
using JetBrains.dotMemoryUnit;
using Xunit;

namespace Chinook.UnitTest.Supervisor
{
    public class ArtistSupervisorTest
    {
        private readonly ChinookSupervisor _super;

        public ArtistSupervisorTest(ChinookSupervisor super)
        {
            _super = super;
        }

        [DotMemoryUnitAttribute(FailIfRunWithoutSupport = false)]
        [Fact]
        public async Task ArtistGetAllAsync()
        {
            // Act
            var artists = await _super.GetAllArtistAsync();

            // Assert
            Assert.Single(artists);
        }

        [AssertTraffic(AllocatedSizeInBytes = 1000, Types = new[] {typeof(Artist)})]
        [Fact]
        public async Task DotMemoryUnitTest()
        {
            var repo = new ArtistRepository();

            await repo.GetAllAsync();

            dotMemory.Check(memory =>
                Assert.Equal(1, memory.GetObjects(where => where.Type.Is<Artist>()).ObjectsCount));

            GC.KeepAlive(repo); // prevent objects from GC if this is implied by test logic
        }
    }
}