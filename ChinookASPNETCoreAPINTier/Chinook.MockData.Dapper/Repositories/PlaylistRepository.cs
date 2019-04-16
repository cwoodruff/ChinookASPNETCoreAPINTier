using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;

namespace Chinook.MockData.Dapper.Repositories
{
    public class PlaylistRepository : IPlaylistRepository
    {
        public void Dispose()
        {
        }

        public async Task<List<Playlist>> GetAllAsync(CancellationToken ct = default)
        {
            IList<Playlist> list = new List<Playlist>();
            var playlist = new Playlist
            {
                PlaylistId = 1,
                Name = "Foo"
            };
            list.Add(playlist);
            return list.ToList();
        }

        public async Task<Playlist> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var playlist = new Playlist
            {
                PlaylistId = id,
                Name = "Foo"
            };
            return playlist;
        }

        public async Task<Playlist> AddAsync(Playlist newPlaylist, CancellationToken ct = default) => newPlaylist;

        public async Task<List<Track>> GetTrackByPlaylistIdAsync(int id,
            CancellationToken ct = default)
        {
            IList<Track> list = new List<Track>();
            var track = new Track
            {
                TrackId = 1,
                Name = "foo",
                AlbumId = 1,
                MediaTypeId = 1,
                GenreId = 1,
                Composer = "foo",
                Milliseconds = 1,
                Bytes = 1,
                UnitPrice = 1
            };
            list.Add(track);
            return list.ToList();
        }

        public async Task<bool> UpdateAsync(Playlist playlist, CancellationToken ct = default) => true;

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default) => true;
    }
}