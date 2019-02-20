using System;
using System.Threading.Tasks;
using Chinook.Domain.Entities;
using Chinook.MockData.Dapper.Repositories;
using JetBrains.dotMemoryUnit;
using Xunit;

namespace Chinook.UnitTest.DataDapper.Repositories
{
    public class GenreRepositoryTest
    {
        private readonly GenreRepository _repo;

        public GenreRepositoryTest()
        {
            _repo = new GenreRepository();
        }

        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        [Fact]
        public async Task GenreGetAllAsync()
        {
            // Act
            var genres = await _repo.GetAllAsync();

            // Assert
            Assert.Single(genres);
        }

        [AssertTraffic(AllocatedSizeInBytes = 1000, Types = new[] {typeof(Genre)})]
        [Fact]
        public async Task DotMemoryUnitTest()
        {
            var repo = new GenreRepository();

            await repo.GetAllAsync();

            dotMemory.Check(memory =>
                Assert.Equal(1, memory.GetObjects(where => where.Type.Is<Genre>()).ObjectsCount));

            GC.KeepAlive(repo); // prevent objects from GC if this is implied by test logic
        }
    }
}