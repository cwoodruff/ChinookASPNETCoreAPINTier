using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Extensions;
using Chinook.Domain.ApiModels;
using Chinook.Domain.Converters;
using Chinook.Domain.Entities;

namespace Chinook.Domain.Supervisor
{
    public partial class ChinookSupervisor
    {
        public async Task<IEnumerable<InvoiceLineApiModel>> GetAllInvoiceLineAsync(
            CancellationToken ct = default)
        {
            var invoiceLines = await _invoiceLineRepository.GetAllAsync(ct);
            return invoiceLines.ConvertAll();
        }

        public async Task<InvoiceLineApiModel> GetInvoiceLineByIdAsync(int id,
            CancellationToken ct = default)
        {
            var invoiceLineViewModel = (await _invoiceLineRepository.GetByIdAsync(id, ct)).Convert;
            invoiceLineViewModel.Track = await GetTrackByIdAsync(invoiceLineViewModel.TrackId, ct);
            invoiceLineViewModel.Invoice = await GetInvoiceByIdAsync(invoiceLineViewModel.InvoiceId, ct);
            invoiceLineViewModel.TrackName = invoiceLineViewModel.Track.Name;
            return invoiceLineViewModel;
        }

        public async Task<IEnumerable<InvoiceLineApiModel>> GetInvoiceLineByInvoiceIdAsync(int id,
            CancellationToken ct = default)
        {
            var invoiceLines = await _invoiceLineRepository.GetByInvoiceIdAsync(id, ct);
            return invoiceLines.ConvertAll();
        }

        public async Task<IEnumerable<InvoiceLineApiModel>> GetInvoiceLineByTrackIdAsync(int id,
            CancellationToken ct = default)
        {
            var invoiceLines = await _invoiceLineRepository.GetByTrackIdAsync(id, ct);
            return invoiceLines.ConvertAll();
        }

        public async Task<InvoiceLineApiModel> AddInvoiceLineAsync(InvoiceLineApiModel newInvoiceLineViewModel,
            CancellationToken ct = default)
        {
            /*var invoiceLine = new InvoiceLine
            {
                InvoiceId = newInvoiceLineViewModel.InvoiceId,
                TrackId = newInvoiceLineViewModel.TrackId,
                UnitPrice = newInvoiceLineViewModel.UnitPrice,
                Quantity = newInvoiceLineViewModel.Quantity
            };*/

            var invoiceLine = newInvoiceLineViewModel.Convert;

            invoiceLine = await _invoiceLineRepository.AddAsync(invoiceLine, ct);
            newInvoiceLineViewModel.InvoiceLineId = invoiceLine.InvoiceLineId;
            return newInvoiceLineViewModel;
        }

        public async Task<bool> UpdateInvoiceLineAsync(InvoiceLineApiModel invoiceLineViewModel,
            CancellationToken ct = default)
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

        public Task<bool> DeleteInvoiceLineAsync(int id, CancellationToken ct = default) 
            => _invoiceLineRepository.DeleteAsync(id, ct);
    }
}