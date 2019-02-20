using System;
using System.Threading.Tasks;
using Chinook.Domain.Entities;
using Chinook.MockData.Dapper.Repositories;
using JetBrains.dotMemoryUnit;
using Xunit;

namespace Chinook.UnitTest.DataDapper.Repositories
{
    public class MediaTypeRepositoryTest
    {
        private readonly MediaTypeRepository _repo;

        public MediaTypeRepositoryTest()
        {
            _repo = new MediaTypeRepository();
        }

        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        [Fact]
        public async Task MediaTypeGetAllAsync()
        {
            // Act
            var mediaTypes = await _repo.GetAllAsync();

            // Assert
            Assert.Single(mediaTypes);
        }

        [AssertTraffic(AllocatedSizeInBytes = 1000, Types = new[] {typeof(MediaType)})]
        [Fact]
        public async Task DotMemoryUnitTest()
        {
            var repo = new MediaTypeRepository();

            await repo.GetAllAsync();

            dotMemory.Check(memory =>
                Assert.Equal(1, memory.GetObjects(where => where.Type.Is<MediaType>()).ObjectsCount));

            GC.KeepAlive(repo); // prevent objects from GC if this is implied by test logic
        }
    }
}