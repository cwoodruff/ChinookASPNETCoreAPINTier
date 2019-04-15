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

        public Task<List<Customer>> GetAllAsync(CancellationToken ct = default)
            => new Customer
            {
                CustomerId = 1
            }.AsListTask();

        public Task<Customer> GetByIdAsync(int id, CancellationToken ct = default)
            => new Customer
            {
                CustomerId = id
            }.AsTask();

        public Task<Customer> AddAsync(Customer newCustomer, CancellationToken ct = default) => newCustomer.AsTask();

        public Task<bool> UpdateAsync(Customer customer, CancellationToken ct = default) => true.AsTask();

        public Task<bool> DeleteAsync(int id, CancellationToken ct = default) => true.AsTask();

        public Task<List<Customer>> GetBySupportRepIdAsync(int id,
            CancellationToken ct = default)
            => new Customer
            {
                CustomerId = id
            }.AsListTask();
    }
}