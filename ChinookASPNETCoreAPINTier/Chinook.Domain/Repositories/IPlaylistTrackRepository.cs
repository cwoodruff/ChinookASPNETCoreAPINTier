using Chinook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chinook.Domain.Repositories
{
    public interface IPlaylistTrackRepository : IDisposable
    {
        Task<List<PlaylistTrack>> GetAllAsync(CancellationToken ct = default(CancellationToken));
        Task<List<PlaylistTrack>> GetByPlaylistIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<PlaylistTrack>> GetByTrackIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<PlaylistTrack> AddAsync(PlaylistTrack newPlaylistTrack, CancellationToken ct = default(CancellationToken));
        Task<bool> UpdateAsync(PlaylistTrack playlistTrack, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken));
    }
}
