using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Extensions;
using Chinook.Domain.Responses;
using Chinook.Domain.Converters;
using Chinook.Domain.Entities;

namespace Chinook.Domain.Supervisor
{
    public partial class ChinookSupervisor
    {
        public async Task<IEnumerable<InvoiceResponse>> GetAllInvoiceAsync(CancellationToken ct = default)
        {
            var invoices = await _invoiceRepository.GetAllAsync(ct);
            return invoices.ConvertAll();
        }
        
        public async Task<InvoiceResponse> GetInvoiceByIdAsync(int id,
            CancellationToken ct = default)
        {
            var invoiceViewModel = (await _invoiceRepository.GetByIdAsync(id, ct)).Convert;
            invoiceViewModel.Customer = await GetCustomerByIdAsync(invoiceViewModel.CustomerId, ct);
            invoiceViewModel.InvoiceLines = (await GetInvoiceLineByInvoiceIdAsync(invoiceViewModel.InvoiceId, ct)).ToList();
            invoiceViewModel.CustomerName =
                $"{invoiceViewModel.Customer.LastName}, {invoiceViewModel.Customer.FirstName}";
            return invoiceViewModel;
        }

        public async Task<IEnumerable<InvoiceResponse>> GetInvoiceByCustomerIdAsync(int id,
            CancellationToken ct = default)
        {
            var invoices = await _invoiceRepository.GetByCustomerIdAsync(id, ct);
            return invoices.ConvertAll();
        }

        public async Task<InvoiceResponse> AddInvoiceAsync(InvoiceResponse newInvoiceViewModel,
            CancellationToken ct = default)
        {
            var invoice = new Invoice
            {
                CustomerId = newInvoiceViewModel.CustomerId,
                InvoiceDate = newInvoiceViewModel.InvoiceDate,
                BillingAddress = newInvoiceViewModel.BillingAddress,
                BillingCity = newInvoiceViewModel.BillingCity,
                BillingState = newInvoiceViewModel.BillingState,
                BillingCountry = newInvoiceViewModel.BillingCountry,
                BillingPostalCode = newInvoiceViewModel.BillingPostalCode,
                Total = newInvoiceViewModel.Total
            };

            invoice = await _invoiceRepository.AddAsync(invoice, ct);
            newInvoiceViewModel.InvoiceId = invoice.InvoiceId;
            return newInvoiceViewModel;
        }

        public async Task<bool> UpdateInvoiceAsync(InvoiceResponse invoiceViewModel,
            CancellationToken ct = default)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(invoiceViewModel.InvoiceId, ct);

            if (invoice == null) return false;
            invoice.InvoiceId = invoiceViewModel.InvoiceId;
            invoice.CustomerId = invoiceViewModel.CustomerId;
            invoice.InvoiceDate = invoiceViewModel.InvoiceDate;
            invoice.BillingAddress = invoiceViewModel.BillingAddress;
            invoice.BillingCity = invoiceViewModel.BillingCity;
            invoice.BillingState = invoiceViewModel.BillingState;
            invoice.BillingCountry = invoiceViewModel.BillingCountry;
            invoice.BillingPostalCode = invoiceViewModel.BillingPostalCode;
            invoice.Total = invoiceViewModel.Total;

            return await _invoiceRepository.UpdateAsync(invoice, ct);
        }

        public Task<bool> DeleteInvoiceAsync(int id, CancellationToken ct = default) 
            => _invoiceRepository.DeleteAsync(id, ct);
    }
}