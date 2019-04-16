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
    public class TrackRepository : ITrackRepository
    {
        private readonly DbInfo _dbInfo;

        public TrackRepository(DbInfo dbInfo)
        {
            _dbInfo = dbInfo;
        }

        private IDbConnection Connection => new SqlConnection(_dbInfo.ConnectionStrings);
        
        public void Dispose()
        {
            
        }

        private async Task<bool> TrackExists(int id, CancellationToken ct = default) => await GetByIdAsync(id, ct) != null;

        public async Task<List<Track>> GetAllAsync(CancellationToken ct = default)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                var tracks = await Connection.QueryAsync<Track>("Select * From Track");
                return tracks.ToList();
            }
        }

        public async Task<Track> GetByIdAsync(int id, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();
                return await cn.QueryFirstOrDefaultAsync<Track>("Select * From Track WHERE Id = @Id", new {id});
            }
        }

        public async Task<Track> AddAsync(Track newTrack, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();

                newTrack.TrackId = await cn.InsertAsync(
                    new Track
                    {
                        Name = newTrack.Name,
                        AlbumId = newTrack.AlbumId,
                        MediaTypeId = newTrack.MediaTypeId,
                        GenreId = newTrack.GenreId,
                        Composer = newTrack.Composer,
                        Milliseconds = newTrack.Milliseconds,
                        Bytes = newTrack.Bytes,
                        UnitPrice = newTrack.UnitPrice
                    });
            }

            return newTrack;
        }

        public async Task<bool> UpdateAsync(Track track, CancellationToken ct = default)
        {
            if (!await TrackExists(track.TrackId, ct))
                return false;

            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    return cn.UpdateAsync(track).Result;
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
                    return await cn.DeleteAsync(new Track {TrackId = id});
                }  
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<List<Track>> GetByAlbumIdAsync(int id, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();
                var tracks = await cn.QueryAsync<Track>("Select * From Track WHERE AlbumId = @Id", new { id });
                return tracks.ToList();
            }
        }

        public async Task<List<Track>> GetByGenreIdAsync(int id, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();
                var tracks = await cn.QueryAsync<Track>("Select * From Track WHERE GenreId = @Id", new { id });
                return tracks.ToList();
            }
        }

        public async Task<List<Track>> GetByMediaTypeIdAsync(int id, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();
                var tracks = await cn.QueryAsync<Track>("Select * From Track WHERE MediaTypeId = @Id", new { id });
                return tracks.ToList();
            }
        }
    }
}