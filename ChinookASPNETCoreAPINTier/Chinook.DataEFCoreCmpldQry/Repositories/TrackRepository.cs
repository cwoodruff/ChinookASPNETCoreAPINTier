using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Chinook.Domain.Repositories;
using Chinook.Domain.Entities;

namespace Chinook.DataEFCoreCmpldQry.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly ChinookContext _context;

        public TrackRepository(ChinookContext context)
        {
            _context = context;
        }

        private async Task<bool> TrackExists(int id, CancellationToken ct = default) 
            => await GetByIdAsync(id, ct) != null;

        public void Dispose() => _context.Dispose();

        public async Task<List<Track>> GetAllAsync(CancellationToken ct = default) 
            => await _context.GetAllTracksAsync();

        public async Task<Track> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var track = await _context.GetTrackAsync(id);
            return track.First();
        }

        public async Task<Track> AddAsync(Track newTrack, CancellationToken ct = default)
        {
            _context.Track.Add(newTrack);
            await _context.SaveChangesAsync(ct);
            return newTrack;
        }

        public async Task<bool> UpdateAsync(Track track, CancellationToken ct = default)
        {
            if (!await TrackExists(track.TrackId, ct))
                return false;
            _context.Track.Update(track);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            if (!await TrackExists(id, ct))
                return false;
            var toRemove = _context.Track.Find(id);
            _context.Track.Remove(toRemove);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<List<Track>> GetByAlbumIdAsync(int id, CancellationToken ct = default) 
            => await _context.GetTracksByAlbumIdAsync(id);

        public async Task<List<Track>> GetByGenreIdAsync(int id, CancellationToken ct = default) 
            => await _context.GetTracksByGenreIdAsync(id);

        public async Task<List<Track>> GetByMediaTypeIdAsync(int id, CancellationToken ct = default) 
            => await _context.GetTracksByMediaTypeIdAsync(id);
    }
}