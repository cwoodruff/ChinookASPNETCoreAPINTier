using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.ViewModels;

namespace Chinook.Domain.Supervisor
{
    public interface IChinookSupervisor
    {
        Task<List<AlbumViewModel>> GetAllAlbumAsync(CancellationToken ct = default(CancellationToken));
        Task<AlbumViewModel> GetAlbumByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<AlbumViewModel>> GetAlbumByArtistIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<AlbumViewModel> AddAlbumAsync(AlbumViewModel newAlbumViewModel, CancellationToken ct = default(CancellationToken));
        Task<bool> UpdateAlbumAsync(AlbumViewModel albumViewModel, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteAlbumAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<ArtistViewModel>> GetAllArtistAsync(CancellationToken ct = default(CancellationToken));
        Task<ArtistViewModel> GetArtistByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<ArtistViewModel> AddArtistAsync(ArtistViewModel newArtistViewModel, CancellationToken ct = default(CancellationToken));
        Task<bool> UpdateArtistAsync(ArtistViewModel artistViewModel, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteArtistAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<CustomerViewModel>> GetAllCustomerAsync(CancellationToken ct = default(CancellationToken));
        Task<CustomerViewModel> GetCustomerByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<CustomerViewModel>> GetCustomerBySupportRepIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<CustomerViewModel> AddCustomerAsync(CustomerViewModel newCustomerViewModel, CancellationToken ct = default(CancellationToken));
        Task<bool> UpdateCustomerAsync(CustomerViewModel customerViewModel, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteCustomerAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<EmployeeViewModel>> GetAllEmployeeAsync(CancellationToken ct = default(CancellationToken));
        Task<EmployeeViewModel> GetEmployeeByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<EmployeeViewModel> GetEmployeeReportsToAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<EmployeeViewModel> AddEmployeeAsync(EmployeeViewModel newEmployeeViewModel, CancellationToken ct = default(CancellationToken));
        Task<bool> UpdateEmployeeAsync(EmployeeViewModel employeeViewModel, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteEmployeeAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<EmployeeViewModel>> GetEmployeeDirectReportsAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<EmployeeViewModel>> GetDirectReportsAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<GenreViewModel>> GetAllGenreAsync(CancellationToken ct = default(CancellationToken));
        Task<GenreViewModel> GetGenreByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<GenreViewModel> AddGenreAsync(GenreViewModel newGenreViewModel, CancellationToken ct = default(CancellationToken));
        Task<bool> UpdateGenreAsync(GenreViewModel genreViewModel, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteGenreAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<InvoiceLineViewModel>> GetAllInvoiceLineAsync(CancellationToken ct = default(CancellationToken));
        Task<InvoiceLineViewModel> GetInvoiceLineByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<InvoiceLineViewModel>> GetInvoiceLineByInvoiceIdAsync(int id,
            CancellationToken ct = default(CancellationToken));
        Task<List<InvoiceLineViewModel>> GetInvoiceLineByTrackIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<InvoiceLineViewModel> AddInvoiceLineAsync(InvoiceLineViewModel newInvoiceLineViewModel,
            CancellationToken ct = default(CancellationToken));
        Task<bool> UpdateInvoiceLineAsync(InvoiceLineViewModel invoiceLineViewModel, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteInvoiceLineAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<InvoiceViewModel>> GetAllInvoiceAsync(CancellationToken ct = default(CancellationToken));
        Task<InvoiceViewModel> GetInvoiceByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<InvoiceViewModel>> GetInvoiceByCustomerIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<InvoiceViewModel> AddInvoiceAsync(InvoiceViewModel newInvoiceViewModel, CancellationToken ct = default(CancellationToken));
        Task<bool> UpdateInvoiceAsync(InvoiceViewModel invoiceViewModel, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteInvoiceAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<MediaTypeViewModel>> GetAllMediaTypeAsync(CancellationToken ct = default(CancellationToken));
        Task<MediaTypeViewModel> GetMediaTypeByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<MediaTypeViewModel> AddMediaTypeAsync(MediaTypeViewModel newMediaTypeViewModel, CancellationToken ct = default(CancellationToken));
        Task<bool> UpdateMediaTypeAsync(MediaTypeViewModel mediaTypeViewModel, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteMediaTypeAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<PlaylistViewModel>> GetAllPlaylistAsync(CancellationToken ct = default(CancellationToken));
        Task<PlaylistViewModel> GetPlaylistByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<PlaylistViewModel> AddPlaylistAsync(PlaylistViewModel newPlaylistViewModel, CancellationToken ct = default(CancellationToken));
        Task<bool> UpdatePlaylistAsync(PlaylistViewModel playlistViewModel, CancellationToken ct = default(CancellationToken));
        Task<bool> DeletePlaylistAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<TrackViewModel>> GetAllTrackAsync(CancellationToken ct = default(CancellationToken));
        Task<TrackViewModel> GetTrackByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<TrackViewModel>> GetTrackByAlbumIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<TrackViewModel>> GetTrackByGenreIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<TrackViewModel>> GetTrackByMediaTypeIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<TrackViewModel>> GetTrackByPlaylistIdIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<TrackViewModel> AddTrackAsync(TrackViewModel newTrackViewModel, CancellationToken ct = default(CancellationToken));
        Task<bool> UpdateTrackAsync(TrackViewModel trackViewModel, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteTrackAsync(int id, CancellationToken ct = default(CancellationToken));
    }
}