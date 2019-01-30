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
        
        private async Task<bool> InvoiceLineExists(int id, CancellationToken ct = default)
        {
            return await GetByIdAsync(id, ct) != null;
        }

        public async Task<List<InvoiceLine>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                return Connection.QueryAsync<InvoiceLine>("Select * From InvoiceLine").Result.ToList();
            }
        }

        public async Task<InvoiceLine> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            using (var cn = Connection)
            {
                cn.Open();
                return cn.QueryFirstOrDefaultAsync<InvoiceLine>("Select * From InvoiceLine WHERE Id = @Id", new {id}).Result;
            }
        }

        public async Task<List<InvoiceLine>> GetByInvoiceIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            using (var cn = Connection)
            {
                cn.Open();
                return cn.QueryAsync<InvoiceLine>("Select * From InvoiceLine WHERE ArtistId = @Id", new { id }).Result.ToList();
            }
        }

        public async Task<List<InvoiceLine>> GetByTrackIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            using (var cn = Connection)
            {
                cn.Open();
                return cn.QueryAsync<InvoiceLine>("Select * From InvoiceLine WHERE ArtistId = @Id", new { id }).Result.ToList();
            }
        }

        public async Task<InvoiceLine> AddAsync(InvoiceLine newInvoiceLine, CancellationToken ct = default(CancellationToken))
        {
            using (var cn = Connection)
            {
                cn.Open();

                newInvoiceLine.InvoiceLineId = cn.InsertAsync(
                    new InvoiceLine
                    {
                        InvoiceLineId = newInvoiceLine.InvoiceLineId,
                        InvoiceId = newInvoiceLine.InvoiceId,
                        TrackId = newInvoiceLine.TrackId,
                        UnitPrice = newInvoiceLine.UnitPrice,
                        Quantity = newInvoiceLine.Quantity
                    }).Result;
            }

            return newInvoiceLine;
        }

        public async Task<bool> UpdateAsync(InvoiceLine invoiceLine, CancellationToken ct = default(CancellationToken))
        {
            if (!await InvoiceLineExists(invoiceLine.InvoiceLineId, ct))
                return false;

            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    return cn.UpdateAsync(invoiceLine).Result;
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
                    return cn.DeleteAsync(new InvoiceLine {InvoiceLineId = id}).Result;
                }  
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}