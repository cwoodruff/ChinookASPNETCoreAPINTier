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
    public class MediaTypeRepository : IMediaTypeRepository
    {
        private readonly DbInfo _dbInfo;

        public MediaTypeRepository(DbInfo dbInfo)
        {
            _dbInfo = dbInfo;
        }

        private IDbConnection Connection => new SqlConnection(_dbInfo.ConnectionStrings);

        public void Dispose()
        {
            
        }

        private async Task<bool> MediaTypeExists(int id, CancellationToken ct = default) => await GetByIdAsync(id, ct) != null;

        public async Task<List<MediaType>> GetAllAsync(CancellationToken ct = default)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                var mediaTypes = await Connection.QueryAsync<MediaType>("Select * From MediaType");
                return mediaTypes.ToList();
            }
        }

        public async Task<MediaType> GetByIdAsync(int id, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();
                return await cn.QueryFirstOrDefaultAsync<MediaType>("Select * From MediaType WHERE Id = @Id", new {id});
            }
        }

        public async Task<MediaType> AddAsync(MediaType newMediaType, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();

                newMediaType.MediaTypeId = await cn.InsertAsync(new MediaType {Name = newMediaType.Name});
            }

            return newMediaType;
        }

        public async Task<bool> UpdateAsync(MediaType mediaType, CancellationToken ct = default)
        {
            if (!await MediaTypeExists(mediaType.MediaTypeId, ct))
                return false;

            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    return await cn.UpdateAsync(mediaType);
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
                    return await cn.DeleteAsync(new MediaType {MediaTypeId = id});
                }  
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}