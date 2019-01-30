using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Chinook.Domain.Repositories;
using Chinook.Domain.Entities;

namespace Chinook.DataEFCoreCmpldQry.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ChinookContext _context;
        
        

        public CustomerRepository(ChinookContext context)
        {
            _context = context;
        }

        private async Task<bool> CustomerExists(int id, CancellationToken ct = default(CancellationToken))
        {
            return await GetByIdAsync(id, ct) != null;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<Customer>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            return await _context.GetAllCustomersAsync();
        }

        public async Task<Customer> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return _context.GetCustomerAsync(id).Result.First();
        }

        public async Task<Customer> AddAsync(Customer newCustomer, CancellationToken ct = default(CancellationToken))
        {
            _context.Customer.Add(newCustomer);
            await _context.SaveChangesAsync(ct);
            return newCustomer;
        }

        public async Task<bool> UpdateAsync(Customer customer, CancellationToken ct = default(CancellationToken))
        {
            if (!await CustomerExists(customer.CustomerId, ct))
                return false;
            _context.Customer.Update(customer);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            if (!await CustomerExists(id, ct))
                return false;
            var toRemove = _context.Customer.Find(id);
            _context.Customer.Remove(toRemove);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<List<Customer>> GetBySupportRepIdAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            return await _context.GetCustomerBySupportRepIdAsync(id);
        }
    }
}