using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Extensions;
using Chinook.Domain.ApiModels;
using System.Linq;
using Chinook.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace Chinook.Domain.Supervisor
{
    public partial class ChinookSupervisor
    {
        public async Task<IEnumerable<GenreApiModel>> GetAllGenreAsync(CancellationToken ct = default)
        {
            var genres = await _genreRepository.GetAllAsync(ct);

            foreach (var genre in genres)
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));
                _cache.Set(genre.GenreId, genre, cacheEntryOptions);
            }
            
            return genres.ConvertAll();
        }

        public async Task<GenreApiModel> GetGenreByIdAsync(int id, CancellationToken ct = default)
        {
            var genre = _cache.Get<Genre>(id);

            if (genre != null)
            {
                var genreApiModel = genre.Convert();
                genreApiModel.Tracks = (await GetTrackByGenreIdAsync(genreApiModel.GenreId, ct)).ToList();
                return genreApiModel;
            }
            else
            {
                var genreApiModel = (await _genreRepository.GetByIdAsync(id, ct)).Convert();
                genreApiModel.Tracks = (await GetTrackByGenreIdAsync(genreApiModel.GenreId, ct)).ToList();
                
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));
                _cache.Set(genreApiModel.GenreId, genreApiModel, cacheEntryOptions);
                
                return genreApiModel;
            }
        }

        public async Task<GenreApiModel> AddGenreAsync(GenreApiModel newGenreApiModel,
            CancellationToken ct = default)
        {
            var genre = newGenreApiModel.Convert();

            genre = await _genreRepository.AddAsync(genre, ct);
            newGenreApiModel.GenreId = genre.GenreId;
            return newGenreApiModel;
        }

        public async Task<bool> UpdateGenreAsync(GenreApiModel genreApiModel,
            CancellationToken ct = default)
        {
            var genre = await _genreRepository.GetByIdAsync(genreApiModel.GenreId, ct);

            if (genre == null) return false;
            genre.GenreId = genreApiModel.GenreId;
            genre.Name = genreApiModel.Name;

            return await _genreRepository.UpdateAsync(genre, ct);
        }

        public Task<bool> DeleteGenreAsync(int id, CancellationToken ct = default) 
            => _genreRepository.DeleteAsync(id, ct);
    }
}