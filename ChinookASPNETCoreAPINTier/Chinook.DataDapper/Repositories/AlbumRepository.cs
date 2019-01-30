using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.DbInfo;
using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Chinook.DataDapper.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly DbInfo _dbInfo;

        public AlbumRepository(DbInfo dbInfo)
        {
            _dbInfo = dbInfo;
        }

        private IDbConnection Connection => new SqlConnection(_dbInfo.ConnectionStrings);

        public void Dispose()
        {
            
        }
        
        private async Task<bool> AlbumExists(int id, CancellationToken ct = default)
        {
            return await GetByIdAsync(id, ct) != null;
        }

        public async Task<List<Album>> GetAllAsync(CancellationToken ct = default)
        { 
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                return Connection.QueryAsync<Album>("Select * From Album").Result.ToList();
            }
        }

        public async Task<Album> GetByIdAsync(int id, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();
                return cn.QueryFirstOrDefaultAsync<Album>("Select * From Album WHERE Id = @Id", new {id}).Result;
            }
        }

        public async Task<List<Album>> GetByArtistIdAsync(int id, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();
                return cn.QueryAsync<Album>("Select * From Album WHERE ArtistId = @Id", new { id }).Result.ToList();
            }
        }

        public async Task<Album> AddAsync(Album newAlbum, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();

                newAlbum.AlbumId = cn.InsertAsync(new Album {Title = newAlbum.Title, ArtistId = newAlbum.ArtistId}).Result;
            }

            return newAlbum;
        }

        public async Task<bool> UpdateAsync(Album album, CancellationToken ct = default)
        {
            if (!await AlbumExists(album.AlbumId, ct))
                return false;

            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    return cn.UpdateAsync(album).Result;
                }
            }
            catch(Exception ex)
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
                    return cn.DeleteAsync(new Album {AlbumId = id}).Result;
                }  
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}