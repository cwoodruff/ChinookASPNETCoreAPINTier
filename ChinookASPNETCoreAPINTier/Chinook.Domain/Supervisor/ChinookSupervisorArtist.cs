using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Extensions;
using Chinook.Domain.ApiModels;
using Chinook.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace Chinook.Domain.Supervisor
{
    public partial class ChinookSupervisor
    {
        public async Task<IEnumerable<ArtistApiModel>> GetAllArtistAsync(CancellationToken ct = default)
        {
            var artists = await _artistRepository.GetAllAsync(ct);
            foreach (var artist in artists)
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));
                _cache.Set(artist.ArtistId, artist, cacheEntryOptions);
            }
            return artists.ConvertAll();
        }

        public async Task<ArtistApiModel> GetArtistByIdAsync(int id, CancellationToken ct = default)
        {
            var artist = _cache.Get<Artist>(id);

            if (artist != null)
            {
                var artistApiModel = artist.Convert();
                artistApiModel.Albums = (await GetAlbumByArtistIdAsync(artistApiModel.ArtistId, ct)).ToList();
                return artistApiModel;
            }
            else
            {
                var artistApiModel = (await _artistRepository.GetByIdAsync(id, ct)).Convert();
                artistApiModel.Albums = (await GetAlbumByArtistIdAsync(artistApiModel.ArtistId, ct)).ToList();

                var cacheEntryOptions =
                    new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));
                _cache.Set(artistApiModel.ArtistId, artistApiModel, cacheEntryOptions);

                return artistApiModel;
            }
        }

        public async Task<ArtistApiModel> AddArtistAsync(ArtistApiModel newArtistApiModel,
            CancellationToken ct = default)
        {
            var artist = newArtistApiModel.Convert();

            artist = await _artistRepository.AddAsync(artist, ct);
            newArtistApiModel.ArtistId = artist.ArtistId;
            return newArtistApiModel;
        }

        public async Task<bool> UpdateArtistAsync(ArtistApiModel artistApiModel,
            CancellationToken ct = default)
        {
            var artist = await _artistRepository.GetByIdAsync(artistApiModel.ArtistId, ct);

            if (artist == null) return false;
            artist.ArtistId = artistApiModel.ArtistId;
            artist.Name = artistApiModel.Name;

            return await _artistRepository.UpdateAsync(artist, ct);
        }

        public Task<bool> DeleteArtistAsync(int id, CancellationToken ct = default) 
            => _artistRepository.DeleteAsync(id, ct);
    }
}