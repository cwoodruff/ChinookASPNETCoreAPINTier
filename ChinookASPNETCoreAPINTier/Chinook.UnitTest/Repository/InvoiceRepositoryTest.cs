using System;
using Chinook.MockData.Repositories;
using System.Threading.Tasks;
using Chinook.Domain.Entities;
using JetBrains.dotMemoryUnit;
using Xunit;

namespace Chinook.UnitTest.Repository
{
    public class InvoiceRepositoryTest
    {
        private readonly InvoiceRepository _repo;

        public InvoiceRepositoryTest()
        {
            _repo = new InvoiceRepository();
        }

        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        [Fact]
        public async Task InvoiceGetAllAsync()
        {
            // Act
            var invoices = await _repo.GetAllAsync();

            // Assert
            Assert.Single(invoices);
        }

        [AssertTraffic(AllocatedSizeInBytes = 1000, Types = new[] {typeof(Invoice)})]
        [Fact]
        public async Task DotMemoryUnitTest()
        {
            var repo = new InvoiceRepository();

            await repo.GetAllAsync();

            dotMemory.Check(memory =>
                Assert.Equal(1, memory.GetObjects(where => where.Type.Is<Invoice>()).ObjectsCount));

            GC.KeepAlive(repo); // prevent objects from GC if this is implied by test logic
        }
    }
}