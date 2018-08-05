using System;
using System.Threading.Tasks;
using Chinook.Domain.Entities;
using Chinook.MockData.Repositories;
using JetBrains.dotMemoryUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chinook.MSUnitTest
{
    [TestClass]
    public class AlbumRepositoryTest
    {
        private readonly AlbumRepository _repo;

        public AlbumRepositoryTest()
        {
            _repo = new AlbumRepository();
        }

        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        [TestMethod]
        public async Task AlbumGetAllAsync()
        {
            // Act
            var albums = await _repo.GetAllAsync();

            // Assert
            Assert.AreEqual(1, albums.Count);
        }

        [DotMemoryUnitAttribute(FailIfRunWithoutSupport = false)]
        [TestMethod]
        public async Task AlbumGetOneAsync()
        {
            // Arrange
            var number = 1;

            // Act
            var album = await _repo.GetByIdAsync(1);

            // Assert
            Assert.AreEqual(number, album.AlbumId);
        }

        [AssertTraffic(AllocatedSizeInBytes = 1000, Types = new[] {typeof(Album)})]
        [TestMethod]
        public async Task DotMemoryUnitTest()
        {
            var repo = new AlbumRepository();

            await repo.GetAllAsync();

            dotMemory.Check(memory =>
                Assert.AreEqual(1, memory.GetObjects(where => where.Type.Is<Album>()).ObjectsCount));

            GC.KeepAlive(repo); // prevent objects from GC if this is implied by test logic
        }
    }
}