using Chinook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chinook.Domain.Repositories
{
    public interface IInvoiceLineRepository : IDisposable
    {
        Task<List<InvoiceLine>> GetAllAsync(CancellationToken ct = default);
        Task<InvoiceLine> GetByIdAsync(int id, CancellationToken ct = default);
        Task<List<InvoiceLine>> GetByInvoiceIdAsync(int id, CancellationToken ct = default);
        Task<List<InvoiceLine>> GetByTrackIdAsync(int id, CancellationToken ct = default);
        Task<InvoiceLine> AddAsync(InvoiceLine newInvoiceLine, CancellationToken ct = default);
        Task<bool> UpdateAsync(InvoiceLine invoiceLine, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}