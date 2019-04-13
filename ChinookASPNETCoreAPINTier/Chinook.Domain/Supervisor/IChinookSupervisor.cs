using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Responses;

namespace Chinook.Domain.Supervisor
{
    public interface IChinookSupervisor
    {
        Task<List<AlbumResponse>> GetAllAlbumAsync(CancellationToken ct = default);
        Task<AlbumResponse> GetAlbumByIdAsync(int id, CancellationToken ct = default);
        Task<List<AlbumResponse>> GetAlbumByArtistIdAsync(int id, CancellationToken ct = default);

        Task<AlbumResponse> AddAlbumAsync(AlbumResponse newAlbumViewModel,
            CancellationToken ct = default);

        Task<bool> UpdateAlbumAsync(AlbumResponse albumViewModel, CancellationToken ct = default);
        Task<bool> DeleteAlbumAsync(int id, CancellationToken ct = default);
        Task<List<ArtistResponse>> GetAllArtistAsync(CancellationToken ct = default);
        Task<ArtistResponse> GetArtistByIdAsync(int id, CancellationToken ct = default);

        Task<ArtistResponse> AddArtistAsync(ArtistResponse newArtistViewModel,
            CancellationToken ct = default);

        Task<bool> UpdateArtistAsync(ArtistResponse artistViewModel,
            CancellationToken ct = default);

        Task<bool> DeleteArtistAsync(int id, CancellationToken ct = default);
        Task<List<CustomerResponse>> GetAllCustomerAsync(CancellationToken ct = default);
        Task<CustomerResponse> GetCustomerByIdAsync(int id, CancellationToken ct = default);

        Task<List<CustomerResponse>> GetCustomerBySupportRepIdAsync(int id,
            CancellationToken ct = default);

        Task<CustomerResponse> AddCustomerAsync(CustomerResponse newCustomerViewModel,
            CancellationToken ct = default);

        Task<bool> UpdateCustomerAsync(CustomerResponse customerViewModel,
            CancellationToken ct = default);

        Task<bool> DeleteCustomerAsync(int id, CancellationToken ct = default);
        Task<List<EmployeeResponse>> GetAllEmployeeAsync(CancellationToken ct = default);
        Task<EmployeeResponse> GetEmployeeByIdAsync(int id, CancellationToken ct = default);
        Task<EmployeeResponse> GetEmployeeReportsToAsync(int id, CancellationToken ct = default);

        Task<EmployeeResponse> AddEmployeeAsync(EmployeeResponse newEmployeeViewModel,
            CancellationToken ct = default);

        Task<bool> UpdateEmployeeAsync(EmployeeResponse employeeViewModel,
            CancellationToken ct = default);

        Task<bool> DeleteEmployeeAsync(int id, CancellationToken ct = default);

        Task<List<EmployeeResponse>> GetEmployeeDirectReportsAsync(int id,
            CancellationToken ct = default);

        Task<List<EmployeeResponse>> GetDirectReportsAsync(int id, CancellationToken ct = default);
        Task<List<GenreResponse>> GetAllGenreAsync(CancellationToken ct = default);
        Task<GenreResponse> GetGenreByIdAsync(int id, CancellationToken ct = default);

        Task<GenreResponse> AddGenreAsync(GenreResponse newGenreViewModel,
            CancellationToken ct = default);

        Task<bool> UpdateGenreAsync(GenreResponse genreViewModel, CancellationToken ct = default);
        Task<bool> DeleteGenreAsync(int id, CancellationToken ct = default);
        Task<List<InvoiceLineResponse>> GetAllInvoiceLineAsync(CancellationToken ct = default);
        Task<InvoiceLineResponse> GetInvoiceLineByIdAsync(int id, CancellationToken ct = default);

        Task<List<InvoiceLineResponse>> GetInvoiceLineByInvoiceIdAsync(int id,
            CancellationToken ct = default);

        Task<List<InvoiceLineResponse>> GetInvoiceLineByTrackIdAsync(int id,
            CancellationToken ct = default);

        Task<InvoiceLineResponse> AddInvoiceLineAsync(InvoiceLineResponse newInvoiceLineViewModel,
            CancellationToken ct = default);

        Task<bool> UpdateInvoiceLineAsync(InvoiceLineResponse invoiceLineViewModel,
            CancellationToken ct = default);

        Task<bool> DeleteInvoiceLineAsync(int id, CancellationToken ct = default);
        Task<List<InvoiceResponse>> GetAllInvoiceAsync(CancellationToken ct = default);
        Task<InvoiceResponse> GetInvoiceByIdAsync(int id, CancellationToken ct = default);

        Task<List<InvoiceResponse>> GetInvoiceByCustomerIdAsync(int id,
            CancellationToken ct = default);

        Task<InvoiceResponse> AddInvoiceAsync(InvoiceResponse newInvoiceViewModel,
            CancellationToken ct = default);

        Task<bool> UpdateInvoiceAsync(InvoiceResponse invoiceViewModel,
            CancellationToken ct = default);

        Task<bool> DeleteInvoiceAsync(int id, CancellationToken ct = default);
        Task<List<MediaTypeResponse>> GetAllMediaTypeAsync(CancellationToken ct = default);
        Task<MediaTypeResponse> GetMediaTypeByIdAsync(int id, CancellationToken ct = default);

        Task<MediaTypeResponse> AddMediaTypeAsync(MediaTypeResponse newMediaTypeViewModel,
            CancellationToken ct = default);

        Task<bool> UpdateMediaTypeAsync(MediaTypeResponse mediaTypeViewModel,
            CancellationToken ct = default);

        Task<bool> DeleteMediaTypeAsync(int id, CancellationToken ct = default);
        Task<List<PlaylistResponse>> GetAllPlaylistAsync(CancellationToken ct = default);
        Task<PlaylistResponse> GetPlaylistByIdAsync(int id, CancellationToken ct = default);

        Task<PlaylistResponse> AddPlaylistAsync(PlaylistResponse newPlaylistViewModel,
            CancellationToken ct = default);

        Task<bool> UpdatePlaylistAsync(PlaylistResponse playlistViewModel,
            CancellationToken ct = default);

        Task<bool> DeletePlaylistAsync(int id, CancellationToken ct = default);
        Task<List<TrackResponse>> GetAllTrackAsync(CancellationToken ct = default);
        Task<TrackResponse> GetTrackByIdAsync(int id, CancellationToken ct = default);
        Task<List<TrackResponse>> GetTrackByAlbumIdAsync(int id, CancellationToken ct = default);
        Task<List<TrackResponse>> GetTrackByGenreIdAsync(int id, CancellationToken ct = default);

        Task<List<TrackResponse>>
            GetTrackByMediaTypeIdAsync(int id, CancellationToken ct = default);

        Task<List<TrackResponse>> GetTrackByPlaylistIdIdAsync(int id,
            CancellationToken ct = default);

        Task<TrackResponse> AddTrackAsync(TrackResponse newTrackViewModel,
            CancellationToken ct = default);

        Task<bool> UpdateTrackAsync(TrackResponse trackViewModel, CancellationToken ct = default);
        Task<bool> DeleteTrackAsync(int id, CancellationToken ct = default);
    }
}