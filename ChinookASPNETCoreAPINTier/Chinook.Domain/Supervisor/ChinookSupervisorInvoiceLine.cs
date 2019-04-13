using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Responses;
using Chinook.Domain.Converters;
using Chinook.Domain.Entities;

namespace Chinook.Domain.Supervisor
{
    public partial class ChinookSupervisor
    {
        public async Task<List<InvoiceLineResponse>> GetAllInvoiceLineAsync(
            CancellationToken ct = default(CancellationToken))
        {
            var invoiceLines = InvoiceLineCoverter.ConvertList(await _invoiceLineRepository.GetAllAsync(ct));
            return invoiceLines;
        }

        public async Task<InvoiceLineResponse> GetInvoiceLineByIdAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            var invoiceLineViewModel = InvoiceLineCoverter.Convert(await _invoiceLineRepository.GetByIdAsync(id, ct));
            invoiceLineViewModel.Track = await GetTrackByIdAsync(invoiceLineViewModel.TrackId, ct);
            invoiceLineViewModel.Invoice = await GetInvoiceByIdAsync(invoiceLineViewModel.InvoiceId, ct);
            invoiceLineViewModel.TrackName = invoiceLineViewModel.Track.Name;
            return invoiceLineViewModel;
        }

        public async Task<List<InvoiceLineResponse>> GetInvoiceLineByInvoiceIdAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            var invoiceLines = await _invoiceLineRepository.GetByInvoiceIdAsync(id, ct);
            return InvoiceLineCoverter.ConvertList(invoiceLines).ToList();
        }

        public async Task<List<InvoiceLineResponse>> GetInvoiceLineByTrackIdAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            var invoiceLines = await _invoiceLineRepository.GetByTrackIdAsync(id, ct);
            return InvoiceLineCoverter.ConvertList(invoiceLines).ToList();
        }

        public async Task<InvoiceLineResponse> AddInvoiceLineAsync(InvoiceLineResponse newInvoiceLineViewModel,
            CancellationToken ct = default(CancellationToken))
        {
            var invoiceLine = new InvoiceLine
            {
                InvoiceId = newInvoiceLineViewModel.InvoiceId,
                TrackId = newInvoiceLineViewModel.TrackId,
                UnitPrice = newInvoiceLineViewModel.UnitPrice,
                Quantity = newInvoiceLineViewModel.Quantity
            };

            invoiceLine = await _invoiceLineRepository.AddAsync(invoiceLine, ct);
            newInvoiceLineViewModel.InvoiceLineId = invoiceLine.InvoiceLineId;
            return newInvoiceLineViewModel;
        }

        public async Task<bool> UpdateInvoiceLineAsync(InvoiceLineResponse invoiceLineViewModel,
            CancellationToken ct = default(CancellationToken))
        {
            var invoiceLine = await _invoiceLineRepository.GetByIdAsync(invoiceLineViewModel.InvoiceId, ct);

            if (invoiceLine == null) return false;
            invoiceLine.InvoiceLineId = invoiceLineViewModel.InvoiceLineId;
            invoiceLine.InvoiceId = invoiceLineViewModel.InvoiceId;
            invoiceLine.TrackId = invoiceLineViewModel.TrackId;
            invoiceLine.UnitPrice = invoiceLineViewModel.UnitPrice;
            invoiceLine.Quantity = invoiceLineViewModel.Quantity;

            return await _invoiceLineRepository.UpdateAsync(invoiceLine, ct);
        }

        public async Task<bool> DeleteInvoiceLineAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _invoiceLineRepository.DeleteAsync(id, ct);
        }
    }
}