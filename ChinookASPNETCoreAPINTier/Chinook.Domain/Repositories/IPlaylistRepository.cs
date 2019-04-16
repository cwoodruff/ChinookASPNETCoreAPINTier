using Chinook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chinook.Domain.Repositories
{
    public interface IPlaylistRepository : IDisposable
    {
        Task<List<Playlist>> GetAllAsync(CancellationToken ct = default);
        Task<Playlist> GetByIdAsync(int id, CancellationToken ct = default);
        Task<Playlist> AddAsync(Playlist newPlaylist, CancellationToken ct = default);
        Task<List<Track>> GetTrackByPlaylistIdAsync(int id, CancellationToken ct = default);
        Task<bool> UpdateAsync(Playlist playlist, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}