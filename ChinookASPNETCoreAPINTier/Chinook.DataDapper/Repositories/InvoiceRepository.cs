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

        private async Task<bool> InvoiceExists(int id, CancellationToken ct = default) => await GetByIdAsync(id, ct) != null;

        public async Task<List<Invoice>> GetAllAsync(CancellationToken ct = default)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                var invoices = await  Connection.QueryAsync<Invoice>("Select * From Invoice");
                return invoices.ToList();
            }
        }

        public async Task<Invoice> GetByIdAsync(int id, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();
                return await cn.QueryFirstOrDefaultAsync<Invoice>("Select * From Invoice WHERE Id = @Id", new {id});
            }
        }

        public async Task<List<Invoice>> GetByCustomerIdAsync(int id, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();
                var invoices = await cn.QueryAsync<Invoice>("Select * From Invoice WHERE ArtistId = @Id", new { id });
                return invoices.ToList();
            }
        }

        public async Task<Invoice> AddAsync(Invoice newInvoice, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();

                newInvoice.InvoiceId = await cn.InsertAsync(
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
                    });
            }

            return newInvoice;
        }

        public async Task<bool> UpdateAsync(Invoice invoice, CancellationToken ct = default)
        {
            if (!await InvoiceExists(invoice.InvoiceId, ct))
                return false;

            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    return await cn.UpdateAsync(invoice);
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
                    return await cn.DeleteAsync(new Invoice {InvoiceId = id});
                }  
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}