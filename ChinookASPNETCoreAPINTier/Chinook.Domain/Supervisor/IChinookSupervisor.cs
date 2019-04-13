using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Responses;

namespace Chinook.Domain.Supervisor
{
    public interface IChinookSupervisor
    {
        Task<List<AlbumResponse>> GetAllAlbumAsync(CancellationToken ct = default(CancellationToken));
        Task<AlbumResponse> GetAlbumByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<AlbumResponse>> GetAlbumByArtistIdAsync(int id, CancellationToken ct = default(CancellationToken));

        Task<AlbumResponse> AddAlbumAsync(AlbumResponse newAlbumViewModel,
            CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateAlbumAsync(AlbumResponse albumViewModel, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteAlbumAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<ArtistResponse>> GetAllArtistAsync(CancellationToken ct = default(CancellationToken));
        Task<ArtistResponse> GetArtistByIdAsync(int id, CancellationToken ct = default(CancellationToken));

        Task<ArtistResponse> AddArtistAsync(ArtistResponse newArtistViewModel,
            CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateArtistAsync(ArtistResponse artistViewModel,
            CancellationToken ct = default(CancellationToken));

        Task<bool> DeleteArtistAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<CustomerResponse>> GetAllCustomerAsync(CancellationToken ct = default(CancellationToken));
        Task<CustomerResponse> GetCustomerByIdAsync(int id, CancellationToken ct = default(CancellationToken));

        Task<List<CustomerResponse>> GetCustomerBySupportRepIdAsync(int id,
            CancellationToken ct = default(CancellationToken));

        Task<CustomerResponse> AddCustomerAsync(CustomerResponse newCustomerViewModel,
            CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateCustomerAsync(CustomerResponse customerViewModel,
            CancellationToken ct = default(CancellationToken));

        Task<bool> DeleteCustomerAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<EmployeeResponse>> GetAllEmployeeAsync(CancellationToken ct = default(CancellationToken));
        Task<EmployeeResponse> GetEmployeeByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<EmployeeResponse> GetEmployeeReportsToAsync(int id, CancellationToken ct = default(CancellationToken));

        Task<EmployeeResponse> AddEmployeeAsync(EmployeeResponse newEmployeeViewModel,
            CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateEmployeeAsync(EmployeeResponse employeeViewModel,
            CancellationToken ct = default(CancellationToken));

        Task<bool> DeleteEmployeeAsync(int id, CancellationToken ct = default(CancellationToken));

        Task<List<EmployeeResponse>> GetEmployeeDirectReportsAsync(int id,
            CancellationToken ct = default(CancellationToken));

        Task<List<EmployeeResponse>> GetDirectReportsAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<GenreResponse>> GetAllGenreAsync(CancellationToken ct = default(CancellationToken));
        Task<GenreResponse> GetGenreByIdAsync(int id, CancellationToken ct = default(CancellationToken));

        Task<GenreResponse> AddGenreAsync(GenreResponse newGenreViewModel,
            CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateGenreAsync(GenreResponse genreViewModel, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteGenreAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<InvoiceLineResponse>> GetAllInvoiceLineAsync(CancellationToken ct = default(CancellationToken));
        Task<InvoiceLineResponse> GetInvoiceLineByIdAsync(int id, CancellationToken ct = default(CancellationToken));

        Task<List<InvoiceLineResponse>> GetInvoiceLineByInvoiceIdAsync(int id,
            CancellationToken ct = default(CancellationToken));

        Task<List<InvoiceLineResponse>> GetInvoiceLineByTrackIdAsync(int id,
            CancellationToken ct = default(CancellationToken));

        Task<InvoiceLineResponse> AddInvoiceLineAsync(InvoiceLineResponse newInvoiceLineViewModel,
            CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateInvoiceLineAsync(InvoiceLineResponse invoiceLineViewModel,
            CancellationToken ct = default(CancellationToken));

        Task<bool> DeleteInvoiceLineAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<InvoiceResponse>> GetAllInvoiceAsync(CancellationToken ct = default(CancellationToken));
        Task<InvoiceResponse> GetInvoiceByIdAsync(int id, CancellationToken ct = default(CancellationToken));

        Task<List<InvoiceResponse>> GetInvoiceByCustomerIdAsync(int id,
            CancellationToken ct = default(CancellationToken));

        Task<InvoiceResponse> AddInvoiceAsync(InvoiceResponse newInvoiceViewModel,
            CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateInvoiceAsync(InvoiceResponse invoiceViewModel,
            CancellationToken ct = default(CancellationToken));

        Task<bool> DeleteInvoiceAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<MediaTypeResponse>> GetAllMediaTypeAsync(CancellationToken ct = default(CancellationToken));
        Task<MediaTypeResponse> GetMediaTypeByIdAsync(int id, CancellationToken ct = default(CancellationToken));

        Task<MediaTypeResponse> AddMediaTypeAsync(MediaTypeResponse newMediaTypeViewModel,
            CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateMediaTypeAsync(MediaTypeResponse mediaTypeViewModel,
            CancellationToken ct = default(CancellationToken));

        Task<bool> DeleteMediaTypeAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<PlaylistResponse>> GetAllPlaylistAsync(CancellationToken ct = default(CancellationToken));
        Task<PlaylistResponse> GetPlaylistByIdAsync(int id, CancellationToken ct = default(CancellationToken));

        Task<PlaylistResponse> AddPlaylistAsync(PlaylistResponse newPlaylistViewModel,
            CancellationToken ct = default(CancellationToken));

        Task<bool> UpdatePlaylistAsync(PlaylistResponse playlistViewModel,
            CancellationToken ct = default(CancellationToken));

        Task<bool> DeletePlaylistAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<TrackResponse>> GetAllTrackAsync(CancellationToken ct = default(CancellationToken));
        Task<TrackResponse> GetTrackByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<TrackResponse>> GetTrackByAlbumIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<TrackResponse>> GetTrackByGenreIdAsync(int id, CancellationToken ct = default(CancellationToken));

        Task<List<TrackResponse>>
            GetTrackByMediaTypeIdAsync(int id, CancellationToken ct = default(CancellationToken));

        Task<List<TrackResponse>> GetTrackByPlaylistIdIdAsync(int id,
            CancellationToken ct = default(CancellationToken));

        Task<TrackResponse> AddTrackAsync(TrackResponse newTrackViewModel,
            CancellationToken ct = default(CancellationToken));

        Task<bool> UpdateTrackAsync(TrackResponse trackViewModel, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteTrackAsync(int id, CancellationToken ct = default(CancellationToken));
    }
}