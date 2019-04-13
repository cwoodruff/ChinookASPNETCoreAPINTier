using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Responses;
using Chinook.Domain.Converters;
using Chinook.Domain.Entities;

namespace Chinook.Domain.Supervisor
{
    public partial class ChinookSupervisor
    {
        public async Task<List<GenreResponse>> GetAllGenreAsync(CancellationToken ct = default(CancellationToken))
        {
            var genres = GenreCoverter.ConvertList(await _genreRepository.GetAllAsync(ct));
            return genres;
        }

        public async Task<GenreResponse> GetGenreByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var genreViewModel = GenreCoverter.Convert(await _genreRepository.GetByIdAsync(id, ct));
            genreViewModel.Tracks = await GetTrackByGenreIdAsync(genreViewModel.GenreId, ct);
            return genreViewModel;
        }

        public async Task<GenreResponse> AddGenreAsync(GenreResponse newGenreViewModel,
            CancellationToken ct = default(CancellationToken))
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
            CancellationToken ct = default(CancellationToken))
        {
            var genre = await _genreRepository.GetByIdAsync(genreViewModel.GenreId, ct);

            if (genre == null) return false;
            genre.GenreId = genreViewModel.GenreId;
            genre.Name = genreViewModel.Name;

            return await _genreRepository.UpdateAsync(genre, ct);
        }

        public async Task<bool> DeleteGenreAsync(int id, CancellationToken ct = default(CancellationToken)) => await _genreRepository.DeleteAsync(id, ct);
    }
}