using Chinook.MockData.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace Chinook.UnitTest.Repository
{
    public class InvoiceRepositoryTest
    {
        private readonly AlbumRepository _repo;

        public InvoiceRepositoryTest()
        {
            _repo = new AlbumRepository();
        }

        [Fact]
        public async Task InvoiceGetAllAsync()
        {
            // Act
            var invoices = await _repo.GetAllAsync();

            // Assert
            Assert.Equal(1, invoices.Count);
        }
    }
}
