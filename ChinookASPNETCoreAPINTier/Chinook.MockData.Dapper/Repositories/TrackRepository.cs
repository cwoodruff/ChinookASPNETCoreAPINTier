using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;

namespace Chinook.MockData.Dapper.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        public void Dispose()
        {
        }

        public async Task<List<Track>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            IList<Track> list = new List<Track>();
            var track = new Track
            {
                TrackId = 1,
                Name = "Foo"
            };
            list.Add(track);
            return list.ToList();
        }

        public async Task<Track> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var track = new Track
            {
                TrackId = id
            };
            return track;
        }

        public async Task<Track> AddAsync(Track newTrack, CancellationToken ct = default(CancellationToken)) => newTrack;

        public async Task<bool> UpdateAsync(Track track, CancellationToken ct = default(CancellationToken)) => true;

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken)) => true;

        public async Task<List<Track>> GetByAlbumIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            IList<Track> list = new List<Track>();
            var track = new Track
            {
                TrackId = id
            };
            list.Add(track);
            return list.ToList();
        }

        public async Task<List<Track>> GetByGenreIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            IList<Track> list = new List<Track>();
            var track = new Track
            {
                TrackId = id
            };
            list.Add(track);
            return list.ToList();
        }

        public async Task<List<Track>> GetByMediaTypeIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            IList<Track> list = new List<Track>();
            var track = new Track
            {
                TrackId = id
            };
            list.Add(track);
            return list.ToList();
        }
    }
}