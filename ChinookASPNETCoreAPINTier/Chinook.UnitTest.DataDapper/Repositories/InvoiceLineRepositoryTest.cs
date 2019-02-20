using System;
using System.Threading.Tasks;
using Chinook.Domain.Entities;
using Chinook.MockData.Dapper.Repositories;
using JetBrains.dotMemoryUnit;
using Xunit;

namespace Chinook.UnitTest.DataDapper.Repositories
{
    public class InvoiceLineRepositoryTest
    {
        private readonly InvoiceLineRepository _repo;

        public InvoiceLineRepositoryTest()
        {
            _repo = new InvoiceLineRepository();
        }

        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        [Fact]
        public async Task InvoiceLineGetAllAsync()
        {
            // Act
            var invoiceLines = await _repo.GetAllAsync();

            // Assert
            Assert.Single(invoiceLines);
        }

        [AssertTraffic(AllocatedSizeInBytes = 1000, Types = new[] {typeof(InvoiceLine)})]
        [Fact]
        public async Task DotMemoryUnitTest()
        {
            var repo = new InvoiceLineRepository();

            await repo.GetAllAsync();

            dotMemory.Check(memory =>
                Assert.Equal(1, memory.GetObjects(where => where.Type.Is<InvoiceLine>()).ObjectsCount));

            GC.KeepAlive(repo); // prevent objects from GC if this is implied by test logic
        }
    }
}