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
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DbInfo _dbInfo;

        public InvoiceRepository(DbInfo dbInfo)
        {
            _dbInfo = dbInfo;
        }

        private IDbConnection Connection => new SqlConnection(_dbInfo.ConnectionStrings);

        public void Dispose()
        {
            
        }
        
        private async Task<bool> InvoiceExists(int id, CancellationToken ct = default)
        {
            return await GetByIdAsync(id, ct) != null;
        }

        public async Task<List<Invoice>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                return Connection.QueryAsync<Invoice>("Select * From Invoice").Result.ToList();
            }
        }

        public async Task<Invoice> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            using (var cn = Connection)
            {
                cn.Open();
                return cn.QueryFirstOrDefaultAsync<Invoice>("Select * From Invoice WHERE Id = @Id", new {id}).Result;
            }
        }

        public async Task<List<Invoice>> GetByCustomerIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            using (var cn = Connection)
            {
                cn.Open();
                return cn.QueryAsync<Invoice>("Select * From Invoice WHERE ArtistId = @Id", new { id }).Result.ToList();
            }
        }

        public async Task<Invoice> AddAsync(Invoice newInvoice, CancellationToken ct = default(CancellationToken))
        {
            using (var cn = Connection)
            {
                cn.Open();

                newInvoice.InvoiceId = cn.InsertAsync(
                    new Invoice
                    {
                        InvoiceId = newInvoice.InvoiceId,
                        CustomerId = newInvoice.CustomerId,
                        InvoiceDate = newInvoice.InvoiceDate,
                        BillingAddress = newInvoice.BillingAddress,
                        BillingCity = newInvoice.BillingCity,
                        BillingState = newInvoice.BillingState,
                        BillingCountry = newInvoice.BillingCountry,
                        BillingPostalCode = newInvoice.BillingPostalCode,
                        Total = newInvoice.Total
                    }).Result;
            }

            return newInvoice;
        }

        public async Task<bool> UpdateAsync(Invoice invoice, CancellationToken ct = default(CancellationToken))
        {
            if (!await InvoiceExists(invoice.InvoiceId, ct))
                return false;

            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    return cn.UpdateAsync(invoice).Result;
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
                    return cn.DeleteAsync(new Invoice {InvoiceId = id}).Result;
                }  
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}