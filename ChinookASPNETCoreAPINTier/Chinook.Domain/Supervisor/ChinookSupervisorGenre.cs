using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Extensions;
using Chinook.Domain.Responses;
using Chinook.Domain.Converters;
using Chinook.Domain.Entities;
using System.Linq;

namespace Chinook.Domain.Supervisor
{
    public partial class ChinookSupervisor
    {
        public async Task<IEnumerable<GenreResponse>> GetAllGenreAsync(CancellationToken ct = default)
        {
            var genres = await _genreRepository.GetAllAsync(ct);
            return genres.ConvertAll();
        }

        public async Task<GenreResponse> GetGenreByIdAsync(int id, CancellationToken ct = default)
        {
            var genreViewModel = (await _genreRepository.GetByIdAsync(id, ct)).Convert;
            genreViewModel.Tracks = (await GetTrackByGenreIdAsync(genreViewModel.GenreId, ct)).ToList();
            return genreViewModel;
        }

        public async Task<GenreResponse> AddGenreAsync(GenreResponse newGenreViewModel,
            CancellationToken ct = default)
        {
            var genre = new Genre
            {
                Name = newGenreViewModel.Name
            };

            genre = await _genreRepository.AddAsync(genre, ct);
            newGenreViewModel.GenreId = genre.GenreId;
            return newGenreViewModel;
        }

        public async Task<bool> UpdateGenreAsync(GenreResponse genreViewModel,
            CancellationToken ct = default)
        {
            var genre = await _genreRepository.GetByIdAsync(genreViewModel.GenreId, ct);

            if (genre == null) return false;
            genre.GenreId = genreViewModel.GenreId;
            genre.Name = genreViewModel.Name;

            return await _genreRepository.UpdateAsync(genre, ct);
        }

        public Task<bool> DeleteGenreAsync(int id, CancellationToken ct = default) 
            => _genreRepository.DeleteAsync(id, ct);
    }
}