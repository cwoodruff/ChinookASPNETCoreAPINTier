using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;

namespace Chinook.MockData.Dapper.Repositories
{
    public class InvoiceLineRepository : IInvoiceLineRepository
    {
        public void Dispose()
        {
        }

        public async Task<List<InvoiceLine>> GetAllAsync(CancellationToken ct = default)
        {
            IList<InvoiceLine> list = new List<InvoiceLine>();
            var invoiceLine = new InvoiceLine
            {
                InvoiceLineId = 1
            };
            list.Add(invoiceLine);
            return list.ToList();
        }

        public async Task<InvoiceLine> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var invoiceLine = new InvoiceLine
            {
                InvoiceLineId = id
            };
            return invoiceLine;
        }

        public async Task<InvoiceLine> AddAsync(InvoiceLine newInvoiceLine,
            CancellationToken ct = default) => newInvoiceLine;

        public async Task<bool> UpdateAsync(InvoiceLine invoiceLine, CancellationToken ct = default) => true;

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default) => true;

        public async Task<List<InvoiceLine>> GetByInvoiceIdAsync(int id,
            CancellationToken ct = default)
        {
            IList<InvoiceLine> list = new List<InvoiceLine>();
            var newisd = new InvoiceLine
            {
                InvoiceLineId = id
            };
            list.Add(newisd);
            return list.ToList();
        }

        public async Task<List<InvoiceLine>> GetByTrackIdAsync(int id,
            CancellationToken ct = default)
        {
            IList<InvoiceLine> list = new List<InvoiceLine>();
            var newisd = new InvoiceLine
            {
                InvoiceLineId = id
            };
            list.Add(newisd);
            return list.ToList();
        }
    }
}