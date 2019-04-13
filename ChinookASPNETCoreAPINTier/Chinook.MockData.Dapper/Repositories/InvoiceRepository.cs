using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;

namespace Chinook.MockData.Dapper.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        public void Dispose()
        {
        }

        public async Task<List<Invoice>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            IList<Invoice> list = new List<Invoice>();
            var invoice = new Invoice
            {
                InvoiceId = 1
            };
            list.Add(invoice);
            return list.ToList();
        }

        public async Task<Invoice> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var invoice = new Invoice
            {
                InvoiceId = id
            };
            return invoice;
        }

        public async Task<Invoice> AddAsync(Invoice newInvoice, CancellationToken ct = default(CancellationToken)) => newInvoice;

        public async Task<bool> UpdateAsync(Invoice invoice, CancellationToken ct = default(CancellationToken)) => true;

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken)) => true;

        public async Task<List<Invoice>> GetByCustomerIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            IList<Invoice> list = new List<Invoice>();
            var invoice = new Invoice
            {
                InvoiceId = id
            };
            list.Add(invoice);
            return list.ToList();
        }
    }
}