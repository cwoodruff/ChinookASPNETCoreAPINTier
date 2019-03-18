using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.ViewModels;
using Chinook.Domain.Converters;
using Chinook.Domain.Entities;

namespace Chinook.Domain.Supervisor
{
    public partial class ChinookSupervisor
    {
        public async Task<List<CustomerViewModel>> GetAllCustomerAsync(
            CancellationToken ct = default(CancellationToken))
        {
            var customers = CustomerCoverter.ConvertList(await _customerRepository.GetAllAsync(ct)).ToList();
            return customers;
        }

        public async Task<CustomerViewModel> GetCustomerByIdAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            var customerViewModel = CustomerCoverter.Convert(await _customerRepository.GetByIdAsync(id, ct));
            customerViewModel.Invoices = await GetInvoiceByCustomerIdAsync(customerViewModel.CustomerId, ct);
            customerViewModel.SupportRep =
                await GetEmployeeByIdAsync(customerViewModel.SupportRepId.GetValueOrDefault(), ct);
            customerViewModel.SupportRepName =
                $"{customerViewModel.SupportRep.LastName}, {customerViewModel.SupportRep.FirstName}";
            return customerViewModel;
        }

        public async Task<List<CustomerViewModel>> GetCustomerBySupportRepIdAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            var customers = await _customerRepository.GetBySupportRepIdAsync(id, ct);
            return CustomerCoverter.ConvertList(customers).ToList();
        }

        public async Task<CustomerViewModel> AddCustomerAsync(CustomerViewModel newCustomerViewModel,
            CancellationToken ct = default(CancellationToken))
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

        public async Task<bool> UpdateCustomerAsync(CustomerViewModel customerViewModel,
            CancellationToken ct = default(CancellationToken))
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

        public async Task<bool> DeleteCustomerAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _customerRepository.DeleteAsync(id, ct);
        }
    }
}