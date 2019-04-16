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
    public class InvoiceLineRepository : IInvoiceLineRepository
    {
        private readonly DbInfo _dbInfo;

        public InvoiceLineRepository(DbInfo dbInfo)
        {
            _dbInfo = dbInfo;
        }

        private IDbConnection Connection => new SqlConnection(_dbInfo.ConnectionStrings);

        public void Dispose()
        {
            
        }

        private async Task<bool> InvoiceLineExists(int id, CancellationToken ct = default) => await GetByIdAsync(id, ct) != null;

        public async Task<List<InvoiceLine>> GetAllAsync(CancellationToken ct = default)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                var invoiceLines = await Connection.QueryAsync<InvoiceLine>("Select * From InvoiceLine");
                return invoiceLines.ToList();
            }
        }

        public async Task<InvoiceLine> GetByIdAsync(int id, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();
                return await cn.QueryFirstOrDefaultAsync<InvoiceLine>("Select * From InvoiceLine WHERE Id = @Id", new {id});
            }
        }

        public async Task<List<InvoiceLine>> GetByInvoiceIdAsync(int id, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();
                var invoiceLines = await cn.QueryAsync<InvoiceLine>("Select * From InvoiceLine WHERE ArtistId = @Id", new { id });
                return invoiceLines.ToList();
            }
        }

        public async Task<List<InvoiceLine>> GetByTrackIdAsync(int id, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();
                var invoiceLines = await  cn.QueryAsync<InvoiceLine>("Select * From InvoiceLine WHERE ArtistId = @Id", new { id });
                return invoiceLines.ToList();
            }
        }

        public async Task<InvoiceLine> AddAsync(InvoiceLine newInvoiceLine, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();

                newInvoiceLine.InvoiceLineId = await cn.InsertAsync(
                    new InvoiceLine
                    {
                        InvoiceLineId = newInvoiceLine.InvoiceLineId,
                        InvoiceId = newInvoiceLine.InvoiceId,
                        TrackId = newInvoiceLine.TrackId,
                        UnitPrice = newInvoiceLine.UnitPrice,
                        Quantity = newInvoiceLine.Quantity
                    });
            }

            return newInvoiceLine;
        }

        public async Task<bool> UpdateAsync(InvoiceLine invoiceLine, CancellationToken ct = default)
        {
            if (!await InvoiceLineExists(invoiceLine.InvoiceLineId, ct))
                return false;

            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    return await cn.UpdateAsync(invoiceLine);
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
                    return await cn.DeleteAsync(new InvoiceLine {InvoiceLineId = id});
                }  
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}