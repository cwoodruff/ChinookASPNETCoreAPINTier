using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IEnumerable<InvoiceApiModel>> GetAllInvoiceAsync(CancellationToken ct = default)
        {
            var invoices = await _invoiceRepository.GetAllAsync(ct);
            foreach (var invoice in invoices)
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));
                _cache.Set(invoice.InvoiceId, invoice, cacheEntryOptions);
            }
            return invoices.ConvertAll();
        }
        
        public async Task<InvoiceApiModel> GetInvoiceByIdAsync(int id,
            CancellationToken ct = default)
        {
            var invoice = _cache.Get<Invoice>(id);

            if (invoice != null)
            {
                var invoiceApiModel = invoice.Convert();
                invoiceApiModel.Customer = await GetCustomerByIdAsync(invoiceApiModel.CustomerId, ct);
                invoiceApiModel.InvoiceLines = (await GetInvoiceLineByInvoiceIdAsync(invoiceApiModel.InvoiceId, ct)).ToList();
                invoiceApiModel.CustomerName =
                    $"{invoiceApiModel.Customer.LastName}, {invoiceApiModel.Customer.FirstName}";
                return invoiceApiModel;
            }
            else
            {
                var invoiceApiModel = (await _invoiceRepository.GetByIdAsync(id, ct)).Convert();
                invoiceApiModel.Customer = await GetCustomerByIdAsync(invoiceApiModel.CustomerId, ct);
                invoiceApiModel.InvoiceLines = (await GetInvoiceLineByInvoiceIdAsync(invoiceApiModel.InvoiceId, ct)).ToList();
                invoiceApiModel.CustomerName =
                    $"{invoiceApiModel.Customer.LastName}, {invoiceApiModel.Customer.FirstName}";

                var cacheEntryOptions =
                    new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));
                _cache.Set(invoiceApiModel.InvoiceId, invoiceApiModel, cacheEntryOptions);

                return invoiceApiModel;
            }
        }

        public async Task<IEnumerable<InvoiceApiModel>> GetInvoiceByCustomerIdAsync(int id,
            CancellationToken ct = default)
        {
            var invoices = await _invoiceRepository.GetByCustomerIdAsync(id, ct);
            return invoices.ConvertAll();
        }

        public async Task<InvoiceApiModel> AddInvoiceAsync(InvoiceApiModel newInvoiceApiModel,
            CancellationToken ct = default)
        {
            /*var invoice = new Invoice
            {
                CustomerId = newInvoiceApiModel.CustomerId,
                InvoiceDate = newInvoiceApiModel.InvoiceDate,
                BillingAddress = newInvoiceApiModel.BillingAddress,
                BillingCity = newInvoiceApiModel.BillingCity,
                BillingState = newInvoiceApiModel.BillingState,
                BillingCountry = newInvoiceApiModel.BillingCountry,
                BillingPostalCode = newInvoiceApiModel.BillingPostalCode,
                Total = newInvoiceApiModel.Total
            };*/

            var invoice = newInvoiceApiModel.Convert();

            invoice = await _invoiceRepository.AddAsync(invoice, ct);
            newInvoiceApiModel.InvoiceId = invoice.InvoiceId;
            return newInvoiceApiModel;
        }

        public async Task<bool> UpdateInvoiceAsync(InvoiceApiModel invoiceApiModel,
            CancellationToken ct = default)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(invoiceApiModel.InvoiceId, ct);

            if (invoice == null) return false;
            invoice.InvoiceId = invoiceApiModel.InvoiceId;
            invoice.CustomerId = invoiceApiModel.CustomerId;
            invoice.InvoiceDate = invoiceApiModel.InvoiceDate;
            invoice.BillingAddress = invoiceApiModel.BillingAddress;
            invoice.BillingCity = invoiceApiModel.BillingCity;
            invoice.BillingState = invoiceApiModel.BillingState;
            invoice.BillingCountry = invoiceApiModel.BillingCountry;
            invoice.BillingPostalCode = invoiceApiModel.BillingPostalCode;
            invoice.Total = invoiceApiModel.Total;

            return await _invoiceRepository.UpdateAsync(invoice, ct);
        }

        public Task<bool> DeleteInvoiceAsync(int id, CancellationToken ct = default) 
            => _invoiceRepository.DeleteAsync(id, ct);
    }
}