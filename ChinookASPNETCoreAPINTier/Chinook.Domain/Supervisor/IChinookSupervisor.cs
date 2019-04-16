using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.ApiModels;

namespace Chinook.Domain.Supervisor
{
    public interface IChinookSupervisor
    {
        Task<IEnumerable<AlbumApiModel>> GetAllAlbumAsync(CancellationToken ct = default);
        Task<AlbumApiModel> GetAlbumByIdAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<AlbumApiModel>> GetAlbumByArtistIdAsync(int id, CancellationToken ct = default);

        Task<AlbumApiModel> AddAlbumAsync(AlbumApiModel newAlbumViewModel,
            CancellationToken ct = default);

        Task<bool> UpdateAlbumAsync(AlbumApiModel albumViewModel, CancellationToken ct = default);
        Task<bool> DeleteAlbumAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<ArtistApiModel>> GetAllArtistAsync(CancellationToken ct = default);
        Task<ArtistApiModel> GetArtistByIdAsync(int id, CancellationToken ct = default);

        Task<ArtistApiModel> AddArtistAsync(ArtistApiModel newArtistViewModel,
            CancellationToken ct = default);

        Task<bool> UpdateArtistAsync(ArtistApiModel artistViewModel,
            CancellationToken ct = default);

        Task<bool> DeleteArtistAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<CustomerApiModel>> GetAllCustomerAsync(CancellationToken ct = default);
        Task<CustomerApiModel> GetCustomerByIdAsync(int id, CancellationToken ct = default);

        Task<IEnumerable<CustomerApiModel>> GetCustomerBySupportRepIdAsync(int id,
            CancellationToken ct = default);

        Task<CustomerApiModel> AddCustomerAsync(CustomerApiModel newCustomerViewModel,
            CancellationToken ct = default);

        Task<bool> UpdateCustomerAsync(CustomerApiModel customerViewModel,
            CancellationToken ct = default);

        Task<bool> DeleteCustomerAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<EmployeeApiModel>> GetAllEmployeeAsync(CancellationToken ct = default);
        Task<EmployeeApiModel> GetEmployeeByIdAsync(int id, CancellationToken ct = default);
        Task<EmployeeApiModel> GetEmployeeReportsToAsync(int id, CancellationToken ct = default);

        Task<EmployeeApiModel> AddEmployeeAsync(EmployeeApiModel newEmployeeViewModel,
            CancellationToken ct = default);

        Task<bool> UpdateEmployeeAsync(EmployeeApiModel employeeViewModel,
            CancellationToken ct = default);

        Task<bool> DeleteEmployeeAsync(int id, CancellationToken ct = default);

        Task<IEnumerable<EmployeeApiModel>> GetEmployeeDirectReportsAsync(int id,
            CancellationToken ct = default);

        Task<IEnumerable<EmployeeApiModel>> GetDirectReportsAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<GenreApiModel>> GetAllGenreAsync(CancellationToken ct = default);
        Task<GenreApiModel> GetGenreByIdAsync(int id, CancellationToken ct = default);

        Task<GenreApiModel> AddGenreAsync(GenreApiModel newGenreViewModel,
            CancellationToken ct = default);

        Task<bool> UpdateGenreAsync(GenreApiModel genreViewModel, CancellationToken ct = default);
        Task<bool> DeleteGenreAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<InvoiceLineApiModel>> GetAllInvoiceLineAsync(CancellationToken ct = default);
        Task<InvoiceLineApiModel> GetInvoiceLineByIdAsync(int id, CancellationToken ct = default);

        Task<IEnumerable<InvoiceLineApiModel>> GetInvoiceLineByInvoiceIdAsync(int id,
            CancellationToken ct = default);

        Task<IEnumerable<InvoiceLineApiModel>> GetInvoiceLineByTrackIdAsync(int id,
            CancellationToken ct = default);

        Task<InvoiceLineApiModel> AddInvoiceLineAsync(InvoiceLineApiModel newInvoiceLineViewModel,
            CancellationToken ct = default);

        Task<bool> UpdateInvoiceLineAsync(InvoiceLineApiModel invoiceLineViewModel,
            CancellationToken ct = default);

        Task<bool> DeleteInvoiceLineAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<InvoiceApiModel>> GetAllInvoiceAsync(CancellationToken ct = default);
        Task<InvoiceApiModel> GetInvoiceByIdAsync(int id, CancellationToken ct = default);

        Task<IEnumerable<InvoiceApiModel>> GetInvoiceByCustomerIdAsync(int id,
            CancellationToken ct = default);

        Task<InvoiceApiModel> AddInvoiceAsync(InvoiceApiModel newInvoiceViewModel,
            CancellationToken ct = default);

        Task<bool> UpdateInvoiceAsync(InvoiceApiModel invoiceViewModel,
            CancellationToken ct = default);

        Task<bool> DeleteInvoiceAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<MediaTypeApiModel>> GetAllMediaTypeAsync(CancellationToken ct = default);
        Task<MediaTypeApiModel> GetMediaTypeByIdAsync(int id, CancellationToken ct = default);

        Task<MediaTypeApiModel> AddMediaTypeAsync(MediaTypeApiModel newMediaTypeViewModel,
            CancellationToken ct = default);

        Task<bool> UpdateMediaTypeAsync(MediaTypeApiModel mediaTypeViewModel,
            CancellationToken ct = default);

        Task<bool> DeleteMediaTypeAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<PlaylistApiModel>> GetAllPlaylistAsync(CancellationToken ct = default);
        Task<PlaylistApiModel> GetPlaylistByIdAsync(int id, CancellationToken ct = default);

        Task<PlaylistApiModel> AddPlaylistAsync(PlaylistApiModel newPlaylistViewModel,
            CancellationToken ct = default);

        Task<bool> UpdatePlaylistAsync(PlaylistApiModel playlistViewModel,
            CancellationToken ct = default);

        Task<bool> DeletePlaylistAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<TrackApiModel>> GetAllTrackAsync(CancellationToken ct = default);
        Task<TrackApiModel> GetTrackByIdAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<TrackApiModel>> GetTrackByAlbumIdAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<TrackApiModel>> GetTrackByGenreIdAsync(int id, CancellationToken ct = default);

        Task<IEnumerable<TrackApiModel>>
            GetTrackByMediaTypeIdAsync(int id, CancellationToken ct = default);

        Task<IEnumerable<TrackApiModel>> GetTrackByPlaylistIdIdAsync(int id,
            CancellationToken ct = default);

        Task<TrackApiModel> AddTrackAsync(TrackApiModel newTrackViewModel,
            CancellationToken ct = default);

        Task<bool> UpdateTrackAsync(TrackApiModel trackViewModel, CancellationToken ct = default);
        Task<bool> DeleteTrackAsync(int id, CancellationToken ct = default);
    }
}