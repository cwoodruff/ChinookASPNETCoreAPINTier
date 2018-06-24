using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Chinook.Domain.Repositories;
using Chinook.Domain.Entities;
namespace Chinook.MockData.Repositories
{
    public class PlaylistTrackRepository : IPlaylistTrackRepository
    {
        public void Dispose()
        {
            
        }

        public async Task<List<PlaylistTrack>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            IList<PlaylistTrack> list = new List<PlaylistTrack>();
            var playlistTrack = new PlaylistTrack
            {
                PlaylistId = 1,
                TrackId = 1
            };
            list.Add(playlistTrack);
            return list.ToList();
        }

        public async Task<List<PlaylistTrack>> GetByPlaylistIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            IList<PlaylistTrack> list = new List<PlaylistTrack>();
                var newisd = new PlaylistTrack
                {
                    PlaylistId = 1,
                    TrackId = 1
                };
                list.Add(newisd);
            return list.ToList();
        }

        public async Task<List<PlaylistTrack>> GetByTrackIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            IList<PlaylistTrack> list = new List<PlaylistTrack>();
                var newisd = new PlaylistTrack
                {
                    PlaylistId = 1,
                    TrackId = 1
                };
                list.Add(newisd);
            return list.ToList();
        }

        public async Task<PlaylistTrack> AddAsync(PlaylistTrack newPlaylistTrack, CancellationToken ct = default(CancellationToken))
        {
            return newPlaylistTrack;
        }

        public async Task<bool> UpdateAsync(PlaylistTrack playlistTrack, CancellationToken ct = default(CancellationToken))
        {
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return true;
        }
    }
}
