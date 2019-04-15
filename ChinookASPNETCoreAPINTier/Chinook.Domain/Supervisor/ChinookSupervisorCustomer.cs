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
        public async Task<IEnumerable<CustomerResponse>> GetAllCustomerAsync(
            CancellationToken ct = default)
        {
            var customers = await _customerRepository.GetAllAsync(ct);
            return customers.ConvertAll();
        }

        public async Task<CustomerResponse> GetCustomerByIdAsync(int id,
            CancellationToken ct = default)
        {
            var customerViewModel = (await _customerRepository.GetByIdAsync(id, ct)).Convert;
            customerViewModel.Invoices = (await GetInvoiceByCustomerIdAsync(customerViewModel.CustomerId, ct)).ToList();
            customerViewModel.SupportRep =
                await GetEmployeeByIdAsync(customerViewModel.SupportRepId.GetValueOrDefault(), ct);
            customerViewModel.SupportRepName =
                $"{customerViewModel.SupportRep.LastName}, {customerViewModel.SupportRep.FirstName}";
            return customerViewModel;
        }

        public async Task<IEnumerable<CustomerResponse>> GetCustomerBySupportRepIdAsync(int id,
            CancellationToken ct = default)
        {
            var customers = await _customerRepository.GetBySupportRepIdAsync(id, ct);
            return customers.ConvertAll();
        }

        public async Task<CustomerResponse> AddCustomerAsync(CustomerResponse newCustomerViewModel,
            CancellationToken ct = default)
        {
            var customer = new Customer
            {
                FirstName = newCustomerViewModel.FirstName,
                LastName = newCustomerViewModel.LastName,
                Company = newCustomerViewModel.Company,
                Address = newCustomerViewModel.Address,
                City = newCustomerViewModel.City,
                State = newCustomerViewModel.State,
                Country = newCustomerViewModel.Country,
                PostalCode = newCustomerViewModel.PostalCode,
                Phone = newCustomerViewModel.Phone,
                Fax = newCustomerViewModel.Fax,
                Email = newCustomerViewModel.Email,
                SupportRepId = newCustomerViewModel.SupportRepId
            };

            customer = await _customerRepository.AddAsync(customer, ct);
            newCustomerViewModel.CustomerId = customer.CustomerId;
            return newCustomerViewModel;
        }

        public async Task<bool> UpdateCustomerAsync(CustomerResponse customerViewModel,
            CancellationToken ct = default)
        {
            var customer = await _customerRepository.GetByIdAsync(customerViewModel.CustomerId, ct);

            if (customer == null) return false;
            customer.FirstName = customerViewModel.FirstName;
            customer.LastName = customerViewModel.LastName;
            customer.Company = customerViewModel.Company;
            customer.Address = customerViewModel.Address;
            customer.City = customerViewModel.City;
            customer.State = customerViewModel.State;
            customer.Country = customerViewModel.Country;
            customer.PostalCode = customerViewModel.PostalCode;
            customer.Phone = customerViewModel.Phone;
            customer.Fax = customerViewModel.Fax;
            customer.Email = customerViewModel.Email;
            customer.SupportRepId = customerViewModel.SupportRepId;

            return await _customerRepository.UpdateAsync(customer, ct);
        }

        public Task<bool> DeleteCustomerAsync(int id, CancellationToken ct = default) 
            => _customerRepository.DeleteAsync(id, ct);
    }
}