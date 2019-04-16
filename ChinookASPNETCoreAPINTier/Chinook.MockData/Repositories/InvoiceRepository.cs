using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Chinook.Domain.Repositories;
using Chinook.Domain.Entities;

namespace Chinook.MockData.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        public void Dispose()
        {
        }

        public Task<List<Invoice>> GetAllAsync(CancellationToken ct = default)
            => new Invoice
            {
                InvoiceId = 1
            }.AsListTask();

        public Task<Invoice> GetByIdAsync(int id, CancellationToken ct = default)
            => new Invoice
            {
                InvoiceId = id
            }.AsTask();

        public Task<Invoice> AddAsync(Invoice newInvoice, CancellationToken ct = default) => newInvoice.AsTask();

        public Task<bool> UpdateAsync(Invoice invoice, CancellationToken ct = default) => true.AsTask();

        public Task<bool> DeleteAsync(int id, CancellationToken ct = default) => true.AsTask();

        public Task<List<Invoice>> GetByCustomerIdAsync(int id, CancellationToken ct = default)
            => new Invoice
            {
                InvoiceId = 1
            }.AsListTask();
    }
}