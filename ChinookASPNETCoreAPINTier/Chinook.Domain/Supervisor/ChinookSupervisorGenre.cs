using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Extensions;
using Chinook.Domain.ApiModels;
using Chinook.Domain.Converters;
using Chinook.Domain.Entities;
using System.Linq;

namespace Chinook.Domain.Supervisor
{
    public partial class ChinookSupervisor
    {
        public async Task<IEnumerable<GenreApiModel>> GetAllGenreAsync(CancellationToken ct = default)
        {
            var genres = await _genreRepository.GetAllAsync(ct);
            return genres.ConvertAll();
        }

        public async Task<GenreApiModel> GetGenreByIdAsync(int id, CancellationToken ct = default)
        {
            var genreApiModel = (await _genreRepository.GetByIdAsync(id, ct)).Convert;
            genreApiModel.Tracks = (await GetTrackByGenreIdAsync(genreApiModel.GenreId, ct)).ToList();
            return genreApiModel;
        }

        public async Task<GenreApiModel> AddGenreAsync(GenreApiModel newGenreApiModel,
            CancellationToken ct = default)
        {
            var genre = new Genre
            {
                Name = newGenreApiModel.Name
            };

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