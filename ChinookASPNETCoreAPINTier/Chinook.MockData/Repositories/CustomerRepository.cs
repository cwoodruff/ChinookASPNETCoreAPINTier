using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Chinook.Domain.Repositories;
using Chinook.Domain.Entities;

namespace Chinook.MockData.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public void Dispose()
        {
            
        }

        public async Task<List<Customer>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            IList<Customer> list = new List<Customer>();

                var customer = new Customer
                {
                    CustomerId = 1
                };
                list.Add(customer);

            return list.ToList();
        }

        public async Task<Customer> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var customer = new Customer
            {
                CustomerId = id
            };
            return customer;
        }

        public async Task<Customer> AddAsync(Customer newCustomer, CancellationToken ct = default(CancellationToken))
        {
            return newCustomer;
        }

        public async Task<bool> UpdateAsync(Customer customer, CancellationToken ct = default(CancellationToken))
        {
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return true;
        }

        public async Task<List<Customer>> GetBySupportRepIdAsync(int id, CancellationToken ct = default(CancellationToken))
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
