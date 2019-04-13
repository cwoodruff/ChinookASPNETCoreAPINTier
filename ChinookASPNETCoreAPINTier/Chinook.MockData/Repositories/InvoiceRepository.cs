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

        public async Task<List<Invoice>> GetAllAsync(CancellationToken ct = default)
        {
            IList<Invoice> list = new List<Invoice>();
            var invoice = new Invoice
            {
                InvoiceId = 1
            };
            list.Add(invoice);
            return list.ToList();
        }

        public async Task<Invoice> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var invoice = new Invoice
            {
                InvoiceId = id
            };
            return invoice;
        }

        public async Task<Invoice> AddAsync(Invoice newInvoice, CancellationToken ct = default) => newInvoice;

        public async Task<bool> UpdateAsync(Invoice invoice, CancellationToken ct = default) => true;

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default) => true;

        public async Task<List<Invoice>> GetByCustomerIdAsync(int id, CancellationToken ct = default)
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