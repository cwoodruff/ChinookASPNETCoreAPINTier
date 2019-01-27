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

namespace Chinook.DataDapper.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private DbInfo _dbInfo;

        public AlbumRepository(DbInfo dbInfo)
        {
            _dbInfo = dbInfo;
        }
        
        public IDbConnection Connection => new SqlConnection(_dbInfo.ConnectionStrings);

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        
        private async Task<bool> AlbumExists(int id, CancellationToken ct = default)
        {
            return await GetByIdAsync(id) != null;
        }

        public async Task<List<Album>> GetAllAsync(CancellationToken ct = default)
        { 
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                return cn.Query<Album>("Select * From Album").ToList();
            }
        }

        public async Task<Album> GetByIdAsync(int id, CancellationToken ct = default)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                return cn.Query<Album>("Select * From Album WHERE Id = @Id", new { id }).SingleOrDefault();
            }
        }

        public async Task<List<Album>> GetByArtistIdAsync(int id, CancellationToken ct = default)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                return cn.Query<Album>("Select * From Album WHERE ArtistId = @Id", new { id }).ToList();
            }
        }

        public async Task<Album> AddAsync(Album newAlbum, CancellationToken ct = default)
        {
            using (IDbConnection cn = Connection)
            {
                var parameters = new
                {
                    newAlbum.Title,
                    newAlbum.ArtistId
                };

                cn.Open();
                newAlbum.AlbumId = cn.Query<int>(
                    "INSERT INTO Album(Title,ArtistId) VALUES (@Title, @ArtistId)", parameters).FirstOrDefault();
            }

            return newAlbum;
        }

        public async Task<bool> UpdateAsync(Album album, CancellationToken ct = default)
        {
            if (!await AlbumExists(album.AlbumId, ct))
                return false;
            
            try
            {
                using (IDbConnection cn = Connection)
                {
                    var parameters = new
                    {
                        album.Title,
                        album.ArtistId,
                        album.AlbumId
                    };
    
                    cn.Open();
                    cn.Execute("UPDATE Album SET Title=@Title, ArtistId=@ArtistId WHERE AlbumId=@AlbumId", parameters);
                }
            return true;
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
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    cn.Execute("DELETE FROM Album WHERE AlbumId = @Id", new { id });
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}