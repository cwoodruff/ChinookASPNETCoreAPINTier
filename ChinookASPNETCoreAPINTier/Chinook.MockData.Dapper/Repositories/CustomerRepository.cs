using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;

namespace Chinook.MockData.Dapper.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public void Dispose()
        {
        }

        public async Task<List<Customer>> GetAllAsync(CancellationToken ct = default)
        {
            IList<Customer> list = new List<Customer>();

            var customer = new Customer
            {
                CustomerId = 1
            };
            list.Add(customer);

            return list.ToList();
        }

        public async Task<Customer> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var customer = new Customer
            {
                CustomerId = id
            };
            return customer;
        }

        public async Task<Customer> AddAsync(Customer newCustomer, CancellationToken ct = default) => newCustomer;

        public async Task<bool> UpdateAsync(Customer customer, CancellationToken ct = default) => true;

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default) => true;

        public async Task<List<Customer>> GetBySupportRepIdAsync(int id,
            CancellationToken ct = default)
        {
            IList<Customer> list = new List<Customer>();
            var customer = new Customer
            {
                CustomerId = id
            };
            list.Add(customer);
            return list.ToList();
        }
    }
}