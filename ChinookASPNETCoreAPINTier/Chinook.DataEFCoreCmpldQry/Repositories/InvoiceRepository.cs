using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;

namespace Chinook.DataEFCoreCmpldQry.Repositories
{
    /// <summary>
    /// The invoice repository.
    /// </summary>
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ChinookContext _context;
        
        public InvoiceRepository(ChinookContext context)
        {
            _context = context;
        }

        private async Task<bool> InvoiceExists(int id, CancellationToken ct = default) 
            => await GetByIdAsync(id, ct) != null;

        public void Dispose() => _context.Dispose();

        public async Task<List<Invoice>> GetAllAsync(CancellationToken ct = default) 
            => await _context.GetAllInvoicesAsync();

        public async Task<Invoice> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var invoice = await _context.GetInvoiceAsync(id);
            return invoice.First();
        }

        public async Task<Invoice> AddAsync(Invoice newInvoice, CancellationToken ct = default)
        {
            _context.Invoice.Add(newInvoice);
            await _context.SaveChangesAsync(ct);
            return newInvoice;
        }

        public async Task<bool> UpdateAsync(Invoice invoice, CancellationToken ct = default)
        {
            if (!await InvoiceExists(invoice.InvoiceId, ct))
                return false;
            _context.Invoice.Update(invoice);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            if (!await InvoiceExists(id, ct))
                return false;
            var toRemove = _context.Invoice.Find(id);
            _context.Invoice.Remove(toRemove);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<List<Invoice>> GetByCustomerIdAsync(int id, CancellationToken ct = default) 
            => await _context.GetInvoicesByCustomerIdAsync(id);
    }
}