using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Repositories;
using Chinook.Domain.ViewModels;
using Chinook.Domain.Converters;
using Chinook.Domain.Entities;

namespace Chinook.Domain.Supervisor
{
    public partial class ChinookSupervisor : IChinookSupervisor
    {
        public async Task<List<ArtistViewModel>> GetAllArtistAsync(CancellationToken ct = default(CancellationToken))
        {
            var artists = ArtistCoverter.ConvertList(await _artistRepository.GetAllAsync(ct));
            return artists.ToList();
        }

        public async Task<ArtistViewModel> GetArtistByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var artistViewModel = ArtistCoverter.Convert(await _artistRepository.GetByIdAsync(id, ct));
            artistViewModel.Albums = await GetAlbumByArtistIdAsync(artistViewModel.ArtistId, ct);
            return artistViewModel;
        }

        public async Task<ArtistViewModel> AddArtistAsync(ArtistViewModel newArtistViewModel,
            CancellationToken ct = default(CancellationToken))
        {
            var artist = new Artist
            {
                Name = newArtistViewModel.Name
            };

            artist = await _artistRepository.AddAsync(artist, ct);
            newArtistViewModel.ArtistId = artist.ArtistId;
            return newArtistViewModel;
        }

        public async Task<bool> UpdateArtistAsync(ArtistViewModel artistViewModel,
            CancellationToken ct = default(CancellationToken))
        {
            var artist = await _artistRepository.GetByIdAsync(artistViewModel.ArtistId, ct);

            if (artist == null) return false;
            artist.ArtistId = artistViewModel.ArtistId;
            artist.Name = artistViewModel.Name;

            return await _artistRepository.UpdateAsync(artist, ct);
        }

        public async Task<bool> DeleteArtistAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _artistRepository.DeleteAsync(id, ct);
        }
    }
}