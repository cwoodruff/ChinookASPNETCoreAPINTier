using Chinook.MockData.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace Chinook.UnitTest.Repository
{
    public class InvoiceLineRepositoryTest
    {
        private readonly AlbumRepository _repo;

        public InvoiceLineRepositoryTest()
        {
            _repo = new AlbumRepository();
        }

        [Fact]
        public async Task InvoiceLineGetAllAsync()
        {
            // Act
            var invoiceLines = await _repo.GetAllAsync();

            // Assert
            Assert.Equal(1, invoiceLines.Count);
        }
    }
}
