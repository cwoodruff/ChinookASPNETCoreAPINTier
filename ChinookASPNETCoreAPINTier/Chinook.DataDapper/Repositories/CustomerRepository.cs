using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Chinook.Domain.DbInfo;
using Chinook.Domain.Repositories;
using Chinook.Domain.Entities;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Chinook.DataDapper.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DbInfo _dbInfo;

        public CustomerRepository(DbInfo dbInfo)
        {
            _dbInfo = dbInfo;
        }

        private IDbConnection Connection => new SqlConnection(_dbInfo.ConnectionStrings);
        
        public void Dispose()
        {
            
        }

        private async Task<bool> CustomerExists(int id, CancellationToken ct = default) => await GetByIdAsync(id, ct) != null;

        public async Task<List<Customer>> GetAllAsync(CancellationToken ct = default)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                var customers = await Connection.QueryAsync<Customer>("Select * From Customer");
                return customers.ToList();
            }
        }

        public async Task<Customer> GetByIdAsync(int id, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();
                return await cn.QueryFirstOrDefaultAsync<Customer>("Select * From Customer WHERE Id = @Id", new {id});
            }
        }

        public async Task<List<Customer>> GetBySupportRepIdAsync(int id, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();
                var customers = await cn.QueryAsync<Customer>("Select * From Customer WHERE ArtistId = @Id", new {id});
                return customers.ToList();
            }
        }

        public async Task<Customer> AddAsync(Customer newCustomer, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();

                newCustomer.CustomerId = await cn.InsertAsync(
                    new Customer
                    {
                        CustomerId = newCustomer.CustomerId,
                        FirstName = newCustomer.FirstName,
                        LastName = newCustomer.LastName,
                        Company = newCustomer.Company,
                        Address = newCustomer.Address,
                        City = newCustomer.City,
                        State = newCustomer.State,
                        Country = newCustomer.Country,
                        PostalCode = newCustomer.PostalCode,
                        Phone = newCustomer.Phone,
                        Fax = newCustomer.Fax,
                        Email = newCustomer.Email,
                        SupportRepId = newCustomer.SupportRepId
                    });
            }

            return newCustomer;
        }

        public async Task<bool> UpdateAsync(Customer customer, CancellationToken ct = default)
        {
            if (!await CustomerExists(customer.CustomerId, ct))
                return false;

            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    return await cn.UpdateAsync(customer);
                }
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    return await cn.DeleteAsync(new Customer {CustomerId = id});
                }  
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}