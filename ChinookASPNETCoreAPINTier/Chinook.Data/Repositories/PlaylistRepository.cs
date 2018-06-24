using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Chinook.Domain.Repositories;
using Chinook.Domain.Entities;
namespace Chinook.Data.Repositories
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly ChinookContext _context;

        public PlaylistRepository(ChinookContext context)
        {
            _context = context;
        }

        private async Task<bool> PlaylistExists(int id, CancellationToken ct = default(CancellationToken))
        {
            return await GetByIdAsync(id, ct) != null;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<Playlist>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            return await _context.Playlist.ToListAsync(ct);
        }

        public async Task<Playlist> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _context.Playlist.FindAsync(id);
        }

        public async Task<List<Track>> GetTrackByPlaylistIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            IList<Track> list = new List<Track>();
            var playlistTracks = _context.PlaylistTrack.Where(p => p.PlaylistId == id);
            foreach (var playlistTrack in playlistTracks)
            {
                var track = await _context.Track.FindAsync(playlistTrack.TrackId);
                list.Add(track);
            }
            return list.ToList();
        }

        public async Task<Playlist> AddAsync(Playlist newPlaylist, CancellationToken ct = default(CancellationToken))
        {
            _context.Playlist.Add(newPlaylist);
            await _context.SaveChangesAsync(ct);
            return newPlaylist;
        }

        public async Task<bool> UpdateAsync(Playlist playlist, CancellationToken ct = default(CancellationToken))
        {
            if (!await PlaylistExists(playlist.PlaylistId, ct))
                return false;
            _context.Playlist.Update(playlist);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            if (!await PlaylistExists(id, ct))
                return false;
            var toRemove = _context.Playlist.Find(id);
            _context.Playlist.Remove(toRemove);
            await _context.SaveChangesAsync(ct);
            return true;
        }
    }
}
