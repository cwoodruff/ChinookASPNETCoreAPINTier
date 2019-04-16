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
    public class ArtistRepository : IArtistRepository
    {
        private readonly DbInfo _dbInfo;

        public ArtistRepository(DbInfo dbInfo)
        {
            _dbInfo = dbInfo;
        }

        private IDbConnection Connection => new SqlConnection(_dbInfo.ConnectionStrings);
        
        public void Dispose()
        {
            
        }

        private async Task<bool> ArtistExists(int id, CancellationToken ct = default) => await GetByIdAsync(id, ct) != null;

        public async Task<List<Artist>> GetAllAsync(CancellationToken ct = default)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                var artists = await Connection.QueryAsync<Artist>("Select * From Artist");
                return artists.ToList();
            }
        }

        public async Task<Artist> GetByIdAsync(int id, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();
                return await cn.QueryFirstOrDefaultAsync<Artist>("Select * From Artist WHERE Id = @Id", new {id});
            }
        }

        public async Task<Artist> AddAsync(Artist newArtist, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();

                 newArtist.ArtistId = await cn.InsertAsync(new Artist {Name = newArtist.Name});
            }

            return newArtist;
        }

        public async Task<bool> UpdateAsync(Artist artist, CancellationToken ct = default)
        {
            if (!await ArtistExists(artist.ArtistId, ct))
                return false;

            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    return await cn.UpdateAsync(artist);
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
                    return await cn.DeleteAsync(new Artist {ArtistId = id});
                }  
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}