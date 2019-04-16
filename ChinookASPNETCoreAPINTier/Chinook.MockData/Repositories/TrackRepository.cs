using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Chinook.Domain.Repositories;
using Chinook.Domain.Entities;

namespace Chinook.MockData.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        public void Dispose()
        {
        }

        public Task<List<Track>> GetAllAsync(CancellationToken ct = default)
            => new Track
            {
                TrackId = 1,
                Name = "Foo"
            }.AsListTask();

        public Task<Track> GetByIdAsync(int id, CancellationToken ct = default)
            => new Track
            {
                TrackId = id
            }.AsTask();

        public Task<Track> AddAsync(Track newTrack, CancellationToken ct = default) => newTrack.AsTask();

        public Task<bool> UpdateAsync(Track track, CancellationToken ct = default) => true.AsTask();

        public Task<bool> DeleteAsync(int id, CancellationToken ct = default) => true.AsTask();

        public Task<List<Track>> GetByAlbumIdAsync(int id, CancellationToken ct = default)
            => new Track
            {
                TrackId = id
            }.AsListTask();

        public Task<List<Track>> GetByGenreIdAsync(int id, CancellationToken ct = default)
            => new Track
            {
                TrackId = id
            }.AsListTask();

        public Task<List<Track>> GetByMediaTypeIdAsync(int id, CancellationToken ct = default)
            => new Track
            {
                TrackId = id
            }.AsListTask();
    }
}