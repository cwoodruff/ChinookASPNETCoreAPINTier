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
        
        private async Task<bool> CustomerExists(int id, CancellationToken ct = default)
        {
            return await GetByIdAsync(id, ct) != null;
        }

        public async Task<List<Customer>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                return Connection.QueryAsync<Customer>("Select * From Customer").Result.ToList();
            }
        }

        public async Task<Customer> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            using (var cn = Connection)
            {
                cn.Open();
                return cn.QueryFirstOrDefaultAsync<Customer>("Select * From Customer WHERE Id = @Id", new {id}).Result;
            }
        }

        public async Task<List<Customer>> GetBySupportRepIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            using (var cn = Connection)
            {
                cn.Open();
                return cn.QueryAsync<Customer>("Select * From Customer WHERE ArtistId = @Id", new { id }).Result.ToList();
            }
        }

        public async Task<Customer> AddAsync(Customer newCustomer, CancellationToken ct = default(CancellationToken))
        {
            using (var cn = Connection)
            {
                cn.Open();

                newCustomer.CustomerId = cn.InsertAsync(
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
                    }).Result;
            }

            return newCustomer;
        }

        public async Task<bool> UpdateAsync(Customer customer, CancellationToken ct = default(CancellationToken))
        {
            if (!await CustomerExists(customer.CustomerId, ct))
                return false;

            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    return cn.UpdateAsync(customer).Result;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    return cn.DeleteAsync(new Customer {CustomerId = id}).Result;
                }  
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}