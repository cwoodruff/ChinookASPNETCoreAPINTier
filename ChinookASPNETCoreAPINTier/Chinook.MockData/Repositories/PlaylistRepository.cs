using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Chinook.Domain.Repositories;
using Chinook.Domain.Entities;
namespace Chinook.MockData.Repositories
{
    public class PlaylistRepository : IPlaylistRepository
    {
        public void Dispose()
        {
            
        }

        public async Task<List<Playlist>> GetAllAsync(CancellationToken ct = default(CancellationToken))
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

        public async Task<Playlist> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var playlist = new Playlist
            {
                PlaylistId = id,
                Name = "Foo"
            };
            return playlist;
        }

        public async Task<Playlist> AddAsync(Playlist newPlaylist, CancellationToken ct = default(CancellationToken))
        {
            return newPlaylist;
        }

        public async Task<List<Track>> GetTrackByPlaylistIdAsync(int id, CancellationToken ct = default(CancellationToken))
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

        public async Task<bool> UpdateAsync(Playlist playlist, CancellationToken ct = default(CancellationToken))
        {
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return true;
        }
    }
}
