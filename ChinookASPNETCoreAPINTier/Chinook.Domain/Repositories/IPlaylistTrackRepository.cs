using Chinook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chinook.Domain.Repositories
{
    public interface IPlaylistTrackRepository : IDisposable
    {
        Task<List<PlaylistTrack>> GetAllAsync(CancellationToken ct = default);
        Task<List<PlaylistTrack>> GetByPlaylistIdAsync(int id, CancellationToken ct = default);
        Task<List<PlaylistTrack>> GetByTrackIdAsync(int id, CancellationToken ct = default);
        Task<PlaylistTrack> AddAsync(PlaylistTrack newPlaylistTrack, CancellationToken ct = default);
        Task<bool> UpdateAsync(PlaylistTrack playlistTrack, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}