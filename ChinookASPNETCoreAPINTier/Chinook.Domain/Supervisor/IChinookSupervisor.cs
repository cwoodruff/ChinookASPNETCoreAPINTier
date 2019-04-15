using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Responses;

namespace Chinook.Domain.Supervisor
{
    public interface IChinookSupervisor
    {
        Task<IEnumerable<AlbumResponse>> GetAllAlbumAsync(CancellationToken ct = default);
        Task<AlbumResponse> GetAlbumByIdAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<AlbumResponse>> GetAlbumByArtistIdAsync(int id, CancellationToken ct = default);

        Task<AlbumResponse> AddAlbumAsync(AlbumResponse newAlbumViewModel,
            CancellationToken ct = default);

        Task<bool> UpdateAlbumAsync(AlbumResponse albumViewModel, CancellationToken ct = default);
        Task<bool> DeleteAlbumAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<ArtistResponse>> GetAllArtistAsync(CancellationToken ct = default);
        Task<ArtistResponse> GetArtistByIdAsync(int id, CancellationToken ct = default);

        Task<ArtistResponse> AddArtistAsync(ArtistResponse newArtistViewModel,
            CancellationToken ct = default);

        Task<bool> UpdateArtistAsync(ArtistResponse artistViewModel,
            CancellationToken ct = default);

        Task<bool> DeleteArtistAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<CustomerResponse>> GetAllCustomerAsync(CancellationToken ct = default);
        Task<CustomerResponse> GetCustomerByIdAsync(int id, CancellationToken ct = default);

        Task<IEnumerable<CustomerResponse>> GetCustomerBySupportRepIdAsync(int id,
            CancellationToken ct = default);

        Task<CustomerResponse> AddCustomerAsync(CustomerResponse newCustomerViewModel,
            CancellationToken ct = default);

        Task<bool> UpdateCustomerAsync(CustomerResponse customerViewModel,
            CancellationToken ct = default);

        Task<bool> DeleteCustomerAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<EmployeeResponse>> GetAllEmployeeAsync(CancellationToken ct = default);
        Task<EmployeeResponse> GetEmployeeByIdAsync(int id, CancellationToken ct = default);
        Task<EmployeeResponse> GetEmployeeReportsToAsync(int id, CancellationToken ct = default);

        Task<EmployeeResponse> AddEmployeeAsync(EmployeeResponse newEmployeeViewModel,
            CancellationToken ct = default);

        Task<bool> UpdateEmployeeAsync(EmployeeResponse employeeViewModel,
            CancellationToken ct = default);

        Task<bool> DeleteEmployeeAsync(int id, CancellationToken ct = default);

        Task<IEnumerable<EmployeeResponse>> GetEmployeeDirectReportsAsync(int id,
            CancellationToken ct = default);

        Task<IEnumerable<EmployeeResponse>> GetDirectReportsAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<GenreResponse>> GetAllGenreAsync(CancellationToken ct = default);
        Task<GenreResponse> GetGenreByIdAsync(int id, CancellationToken ct = default);

        Task<GenreResponse> AddGenreAsync(GenreResponse newGenreViewModel,
            CancellationToken ct = default);

        Task<bool> UpdateGenreAsync(GenreResponse genreViewModel, CancellationToken ct = default);
        Task<bool> DeleteGenreAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<InvoiceLineResponse>> GetAllInvoiceLineAsync(CancellationToken ct = default);
        Task<InvoiceLineResponse> GetInvoiceLineByIdAsync(int id, CancellationToken ct = default);

        Task<IEnumerable<InvoiceLineResponse>> GetInvoiceLineByInvoiceIdAsync(int id,
            CancellationToken ct = default);

        Task<IEnumerable<InvoiceLineResponse>> GetInvoiceLineByTrackIdAsync(int id,
            CancellationToken ct = default);

        Task<InvoiceLineResponse> AddInvoiceLineAsync(InvoiceLineResponse newInvoiceLineViewModel,
            CancellationToken ct = default);

        Task<bool> UpdateInvoiceLineAsync(InvoiceLineResponse invoiceLineViewModel,
            CancellationToken ct = default);

        Task<bool> DeleteInvoiceLineAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<InvoiceResponse>> GetAllInvoiceAsync(CancellationToken ct = default);
        Task<InvoiceResponse> GetInvoiceByIdAsync(int id, CancellationToken ct = default);

        Task<IEnumerable<InvoiceResponse>> GetInvoiceByCustomerIdAsync(int id,
            CancellationToken ct = default);

        Task<InvoiceResponse> AddInvoiceAsync(InvoiceResponse newInvoiceViewModel,
            CancellationToken ct = default);

        Task<bool> UpdateInvoiceAsync(InvoiceResponse invoiceViewModel,
            CancellationToken ct = default);

        Task<bool> DeleteInvoiceAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<MediaTypeResponse>> GetAllMediaTypeAsync(CancellationToken ct = default);
        Task<MediaTypeResponse> GetMediaTypeByIdAsync(int id, CancellationToken ct = default);

        Task<MediaTypeResponse> AddMediaTypeAsync(MediaTypeResponse newMediaTypeViewModel,
            CancellationToken ct = default);

        Task<bool> UpdateMediaTypeAsync(MediaTypeResponse mediaTypeViewModel,
            CancellationToken ct = default);

        Task<bool> DeleteMediaTypeAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<PlaylistResponse>> GetAllPlaylistAsync(CancellationToken ct = default);
        Task<PlaylistResponse> GetPlaylistByIdAsync(int id, CancellationToken ct = default);

        Task<PlaylistResponse> AddPlaylistAsync(PlaylistResponse newPlaylistViewModel,
            CancellationToken ct = default);

        Task<bool> UpdatePlaylistAsync(PlaylistResponse playlistViewModel,
            CancellationToken ct = default);

        Task<bool> DeletePlaylistAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<TrackResponse>> GetAllTrackAsync(CancellationToken ct = default);
        Task<TrackResponse> GetTrackByIdAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<TrackResponse>> GetTrackByAlbumIdAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<TrackResponse>> GetTrackByGenreIdAsync(int id, CancellationToken ct = default);

        Task<IEnumerable<TrackResponse>>
            GetTrackByMediaTypeIdAsync(int id, CancellationToken ct = default);

        Task<IEnumerable<TrackResponse>> GetTrackByPlaylistIdIdAsync(int id,
            CancellationToken ct = default);

        Task<TrackResponse> AddTrackAsync(TrackResponse newTrackViewModel,
            CancellationToken ct = default);

        Task<bool> UpdateTrackAsync(TrackResponse trackViewModel, CancellationToken ct = default);
        Task<bool> DeleteTrackAsync(int id, CancellationToken ct = default);
    }
}