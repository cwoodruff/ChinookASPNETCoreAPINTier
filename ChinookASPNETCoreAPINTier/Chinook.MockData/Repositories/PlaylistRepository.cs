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

        public Task<List<Playlist>> GetAllAsync(CancellationToken ct = default)
            => new Playlist
            {
                PlaylistId = 1,
                Name = "Foo"
            }.AsListTask();

        public Task<Playlist> GetByIdAsync(int id, CancellationToken ct = default)
            => new Playlist
            {
                PlaylistId = id,
                Name = "Foo"
            }.AsTask();

        public Task<Playlist> AddAsync(Playlist newPlaylist, CancellationToken ct = default) => newPlaylist.AsTask();

        public Task<List<Track>> GetTrackByPlaylistIdAsync(int id,
            CancellationToken ct = default)
            => new Track
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
            }.AsListTask();

        public Task<bool> UpdateAsync(Playlist playlist, CancellationToken ct = default) => true.AsTask();

        public Task<bool> DeleteAsync(int id, CancellationToken ct = default) => true.AsTask();
    }
}