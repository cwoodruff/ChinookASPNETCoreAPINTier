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
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly DbInfo _dbInfo;

        public PlaylistRepository(DbInfo dbInfo)
        {
            _dbInfo = dbInfo;
        }

        private IDbConnection Connection => new SqlConnection(_dbInfo.ConnectionStrings);

        public void Dispose()
        {
            
        }

        private async Task<bool> PlaylistExists(int id, CancellationToken ct = default) => await GetByIdAsync(id, ct) != null;

        public async Task<List<Playlist>> GetAllAsync(CancellationToken ct = default)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                var playlists = await Connection.QueryAsync<Playlist>("Select * From Playlist");
                return playlists.ToList();
            }
        }

        public async Task<Playlist> GetByIdAsync(int id, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();
                return await cn.QueryFirstOrDefaultAsync<Playlist>("Select * From Playlist WHERE Id = @Id", new {id});
            }
        }

        public async Task<Playlist> AddAsync(Playlist newPlaylist, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();

                newPlaylist.PlaylistId = await cn.InsertAsync(new Playlist {Name = newPlaylist.Name});
            }

            return newPlaylist;
        }

        public async Task<List<Track>> GetTrackByPlaylistIdAsync(int id, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();
                var tracks = await cn.QueryAsync<Track>(
                    "SELECT Track.* FROM Playlist INNER JOIN PlaylistTrack ON Playlist.PlaylistId = PlaylistTrack.PlaylistId INNER JOIN Track ON PlaylistTrack.TrackId = Track.TrackId WHERE Playlist.PlaylistId = @Id", new { id });
                return tracks.ToList();
            }
        }

        public async Task<bool> UpdateAsync(Playlist playlist, CancellationToken ct = default)
        {
            if (!await PlaylistExists(playlist.PlaylistId, ct))
                return false;

            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    return await cn.UpdateAsync(playlist);
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
                    return await cn.DeleteAsync(new Playlist {PlaylistId = id});
                }  
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}