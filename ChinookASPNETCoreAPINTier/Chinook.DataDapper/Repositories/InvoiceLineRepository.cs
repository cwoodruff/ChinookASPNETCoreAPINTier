using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Chinook.Domain.Repositories;
using Chinook.Domain.Entities;

namespace Chinook.DataDapper.Repositories
{
    public class InvoiceLineRepository : IInvoiceLineRepository
    {
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<InvoiceLine>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public async Task<InvoiceLine> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<InvoiceLine>> GetByInvoiceIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<InvoiceLine>> GetByTrackIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public async Task<InvoiceLine> AddAsync(InvoiceLine newInvoiceLine, CancellationToken ct = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UpdateAsync(InvoiceLine invoiceLine, CancellationToken ct = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }
    }
}