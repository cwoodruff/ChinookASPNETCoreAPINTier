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
    public class PlaylistTrackRepository : IPlaylistTrackRepository
    {
        private readonly DbInfo _dbInfo;

        public PlaylistTrackRepository(DbInfo dbInfo)
        {
            _dbInfo = dbInfo;
        }

        private IDbConnection Connection => new SqlConnection(_dbInfo.ConnectionStrings);
        
        public void Dispose()
        {
            
        }

        public async Task<List<PlaylistTrack>> GetAllAsync(CancellationToken ct = default)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                var playListTracks = await Connection.QueryAsync<PlaylistTrack>("Select * From PlaylistTrack");
                return playListTracks.ToList();
            }
        }

        public async Task<List<PlaylistTrack>> GetByPlaylistIdAsync(int id, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();
                var playListTracks = await cn.QueryAsync<PlaylistTrack>("Select * From PlaylistTrack WHERE ArtistId = @Id", new { id });
                return playListTracks.ToList();
            }
        }

        public async Task<List<PlaylistTrack>> GetByTrackIdAsync(int id, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();
                var playListTracks = await cn.QueryAsync<PlaylistTrack>("Select * From PlaylistTrack WHERE ArtistId = @Id", new { id });
                return playListTracks.ToList();
            }
        }

        public async Task<PlaylistTrack> AddAsync(PlaylistTrack newPlaylistTrack, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();

                await cn.InsertAsync(new PlaylistTrack {PlaylistId = newPlaylistTrack.PlaylistId, TrackId = newPlaylistTrack.TrackId});
            }

            return newPlaylistTrack;
        }

        public async Task<bool> UpdateAsync(PlaylistTrack playlistTrack, CancellationToken ct = default)
        {
            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    return await cn.UpdateAsync(playlistTrack);
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
                    return await cn.DeleteAsync(new PlaylistTrack {PlaylistId = id});
                }  
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}