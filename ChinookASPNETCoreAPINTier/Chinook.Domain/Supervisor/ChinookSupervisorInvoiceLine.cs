using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Extensions;
using Chinook.Domain.ApiModels;
using Chinook.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace Chinook.Domain.Supervisor
{
    public partial class ChinookSupervisor
    {
        public async Task<IEnumerable<InvoiceLineApiModel>> GetAllInvoiceLineAsync(
            CancellationToken ct = default)
        {
            var invoiceLines = await _invoiceLineRepository.GetAllAsync(ct);
            foreach (var invoiceLine in invoiceLines)
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));
                _cache.Set(invoiceLine.InvoiceLineId, invoiceLine, cacheEntryOptions);
            }
            return invoiceLines.ConvertAll();
        }

        public async Task<InvoiceLineApiModel> GetInvoiceLineByIdAsync(int id,
            CancellationToken ct = default)
        {
            var invoiceLine = _cache.Get<InvoiceLine>(id);

            if (invoiceLine != null)
            {
                var invoiceLineApiModel = invoiceLine.Convert();
                invoiceLineApiModel.Track = await GetTrackByIdAsync(invoiceLineApiModel.TrackId, ct);
                invoiceLineApiModel.Invoice = await GetInvoiceByIdAsync(invoiceLineApiModel.InvoiceId, ct);
                invoiceLineApiModel.TrackName = invoiceLineApiModel.Track.Name;
                return invoiceLineApiModel;
            }
            else
            {
                var invoiceLineApiModel = (await _invoiceLineRepository.GetByIdAsync(id, ct)).Convert();
                invoiceLineApiModel.Track = await GetTrackByIdAsync(invoiceLineApiModel.TrackId, ct);
                invoiceLineApiModel.Invoice = await GetInvoiceByIdAsync(invoiceLineApiModel.InvoiceId, ct);
                invoiceLineApiModel.TrackName = invoiceLineApiModel.Track.Name;

                var cacheEntryOptions =
                    new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));
                _cache.Set(invoiceLineApiModel.InvoiceLineId, invoiceLineApiModel, cacheEntryOptions);

                return invoiceLineApiModel;
            }
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

        public async Task<InvoiceLineApiModel> AddInvoiceLineAsync(InvoiceLineApiModel newInvoiceLineApiModel,
            CancellationToken ct = default)
        {
            /*var invoiceLine = new InvoiceLine
            {
                InvoiceId = newInvoiceLineApiModel.InvoiceId,
                TrackId = newInvoiceLineApiModel.TrackId,
                UnitPrice = newInvoiceLineApiModel.UnitPrice,
                Quantity = newInvoiceLineApiModel.Quantity
            };*/

            var invoiceLine = newInvoiceLineApiModel.Convert();

            invoiceLine = await _invoiceLineRepository.AddAsync(invoiceLine, ct);
            newInvoiceLineApiModel.InvoiceLineId = invoiceLine.InvoiceLineId;
            return newInvoiceLineApiModel;
        }

        public async Task<bool> UpdateInvoiceLineAsync(InvoiceLineApiModel invoiceLineApiModel,
            CancellationToken ct = default)
        {
            var invoiceLine = await _invoiceLineRepository.GetByIdAsync(invoiceLineApiModel.InvoiceId, ct);

            if (invoiceLine == null) return false;
            invoiceLine.InvoiceLineId = invoiceLineApiModel.InvoiceLineId;
            invoiceLine.InvoiceId = invoiceLineApiModel.InvoiceId;
            invoiceLine.TrackId = invoiceLineApiModel.TrackId;
            invoiceLine.UnitPrice = invoiceLineApiModel.UnitPrice;
            invoiceLine.Quantity = invoiceLineApiModel.Quantity;

            return await _invoiceLineRepository.UpdateAsync(invoiceLine, ct);
        }

        public Task<bool> DeleteInvoiceLineAsync(int id, CancellationToken ct = default) 
            => _invoiceLineRepository.DeleteAsync(id, ct);
    }
}