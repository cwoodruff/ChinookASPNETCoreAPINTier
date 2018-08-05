using System;
using Chinook.MockData.Repositories;
using System.Threading.Tasks;
using Chinook.Domain.Entities;
using JetBrains.dotMemoryUnit;
using Xunit;

namespace Chinook.UnitTest.Repository
{
    public class CustomerRepositoryTest
    {
        private readonly CustomerRepository _repo;

        public CustomerRepositoryTest()
        {
            _repo = new CustomerRepository();
        }

        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        [Fact]
        public async Task CustomerGetAllAsync()
        {
            // Act
            var customers = await _repo.GetAllAsync();

            // Assert
            Assert.Single(customers);
        }

        [AssertTraffic(AllocatedSizeInBytes = 1000, Types = new[] {typeof(Customer)})]
        [Fact]
        public async Task DotMemoryUnitTest()
        {
            var repo = new CustomerRepository();

            await repo.GetAllAsync();

            dotMemory.Check(memory =>
                Assert.Equal(1, memory.GetObjects(where => where.Type.Is<Customer>()).ObjectsCount));

            GC.KeepAlive(repo); // prevent objects from GC if this is implied by test logic
        }
    }
}