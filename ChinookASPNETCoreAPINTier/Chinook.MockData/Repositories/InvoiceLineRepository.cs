using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Chinook.Domain.Repositories;
using Chinook.Domain.Entities;

namespace Chinook.MockData.Repositories
{
    public class InvoiceLineRepository : IInvoiceLineRepository
    {
        public void Dispose()
        {
        }

        public Task<List<InvoiceLine>> GetAllAsync(CancellationToken ct = default)
            => new InvoiceLine
            {
                InvoiceLineId = 1
            }.AsListTask();

        public Task<InvoiceLine> GetByIdAsync(int id, CancellationToken ct = default)
            => new InvoiceLine
            {
                InvoiceLineId = id
            }.AsTask();

        public Task<InvoiceLine> AddAsync(InvoiceLine newInvoiceLine,
            CancellationToken ct = default) => newInvoiceLine.AsTask();

        public Task<bool> UpdateAsync(InvoiceLine invoiceLine, CancellationToken ct = default) => true.AsTask();

        public Task<bool> DeleteAsync(int id, CancellationToken ct = default) => true.AsTask();

        public Task<List<InvoiceLine>> GetByInvoiceIdAsync(int id,
            CancellationToken ct = default)
            => new InvoiceLine
            {
                InvoiceLineId = id
            }.AsListTask();

        public Task<List<InvoiceLine>> GetByTrackIdAsync(int id,
            CancellationToken ct = default)
            => new InvoiceLine
            {
                InvoiceLineId = id
            }.AsListTask();
    }
}