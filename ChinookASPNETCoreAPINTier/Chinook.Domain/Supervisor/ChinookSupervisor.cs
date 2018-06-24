using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Repositories;
using Chinook.Domain.ViewModels;
using Chinook.Domain.Converters;
using Chinook.Domain.Entities;

namespace Chinook.Domain.Supervisor
{
    public class ChinookSupervisor : IChinookSupervisor
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IInvoiceLineRepository _invoiceLineRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMediaTypeRepository _mediaTypeRepository;
        private readonly IPlaylistRepository _playlistRepository;
        private readonly ITrackRepository _trackRepository;

        public ChinookSupervisor(IAlbumRepository albumRepository,
            IArtistRepository artistRepository,
            ICustomerRepository customerRepository,
            IEmployeeRepository employeeRepository,
            IGenreRepository genreRepository,
            IInvoiceLineRepository invoiceLineRepository,
            IInvoiceRepository invoiceRepository,
            IMediaTypeRepository mediaTypeRepository,
            IPlaylistRepository playlistRepository,
            ITrackRepository trackRepository
            )
        {
            _albumRepository = albumRepository;
            _artistRepository = artistRepository;
            _customerRepository = customerRepository;
            _employeeRepository = employeeRepository;
            _genreRepository = genreRepository;
            _invoiceLineRepository = invoiceLineRepository;
            _invoiceRepository = invoiceRepository;
            _mediaTypeRepository = mediaTypeRepository;
            _playlistRepository = playlistRepository;
            _trackRepository = trackRepository;
        }

        public async Task<List<AlbumViewModel>> GetAllAlbumAsync(CancellationToken ct = default(CancellationToken))
        {
            var albums = AlbumCoverter.ConvertList(await _albumRepository.GetAllAsync(ct));
            foreach (var album in albums)
            {
                album.Artist = await GetArtistByIdAsync(album.ArtistId, ct);
                album.Tracks = await GetTrackByAlbumIdAsync(album.AlbumId, ct);
                album.ArtistName = album.Artist.Name;

            }
            return albums.ToList();
        }

        public async Task<AlbumViewModel> GetAlbumByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var albumViewModel = AlbumCoverter.Convert(await _albumRepository.GetByIdAsync(id, ct));
            albumViewModel.Artist = await GetArtistByIdAsync(albumViewModel.ArtistId, ct);
            albumViewModel.Tracks = await GetTrackByAlbumIdAsync(albumViewModel.AlbumId, ct);
            albumViewModel.ArtistName = albumViewModel.Artist.Name;
            return albumViewModel;
        }

        public async Task<List<AlbumViewModel>> GetAlbumByArtistIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var albums = await _albumRepository.GetByArtistIdAsync(id, ct);
            return AlbumCoverter.ConvertList(albums).ToList();
        }

        public async Task<AlbumViewModel> AddAlbumAsync(AlbumViewModel newAlbumViewModel, CancellationToken ct = default(CancellationToken))
        {
            var album = new Album
            {
                Title = newAlbumViewModel.Title,
                ArtistId = newAlbumViewModel.ArtistId
            };

            album = await _albumRepository.AddAsync(album, ct);
            newAlbumViewModel.AlbumId = album.AlbumId;
            return newAlbumViewModel;
        }

        public async Task<bool> UpdateAlbumAsync(AlbumViewModel albumViewModel, CancellationToken ct = default(CancellationToken))
        {
            var album = await _albumRepository.GetByIdAsync(albumViewModel.AlbumId, ct);

            if (album == null) return false;
            album.AlbumId = albumViewModel.AlbumId;
            album.Title = albumViewModel.Title;
            album.ArtistId = albumViewModel.ArtistId;
                
            return await _albumRepository.UpdateAsync(album, ct);

        }

        public async Task<bool> DeleteAlbumAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _albumRepository.DeleteAsync(id, ct);
        }

        public async Task<List<ArtistViewModel>> GetAllArtistAsync(CancellationToken ct = default(CancellationToken))
        {
            var artists = ArtistCoverter.ConvertList(await _artistRepository.GetAllAsync(ct));
            foreach (var artist in artists)
            {
                artist.Albums = await GetAlbumByArtistIdAsync(artist.ArtistId, ct);
            }
            return artists.ToList();
        }

        public async Task<ArtistViewModel> GetArtistByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var artistViewModel = ArtistCoverter.Convert(await _artistRepository.GetByIdAsync(id, ct));
            artistViewModel.Albums = await GetAlbumByArtistIdAsync(artistViewModel.ArtistId, ct);
            return artistViewModel;
        }

        public async Task<ArtistViewModel> AddArtistAsync(ArtistViewModel newArtistViewModel, CancellationToken ct = default(CancellationToken))
        {
            var artist = new Artist
            {
               Name = newArtistViewModel.Name
            };

            artist = await _artistRepository.AddAsync(artist, ct);
            newArtistViewModel.ArtistId = artist.ArtistId;
            return newArtistViewModel;
        }

        public async Task<bool> UpdateArtistAsync(ArtistViewModel artistViewModel, CancellationToken ct = default(CancellationToken))
        {
            var artist = await _artistRepository.GetByIdAsync(artistViewModel.ArtistId, ct);

            if (artist == null) return false;
            artist.ArtistId = artistViewModel.ArtistId;
            artist.Name = artistViewModel.Name;
                
            return await _artistRepository.UpdateAsync(artist, ct);

        }

        public async Task<bool> DeleteArtistAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _artistRepository.DeleteAsync(id, ct);
        }

        public async Task<List<CustomerViewModel>> GetAllCustomerAsync(CancellationToken ct = default(CancellationToken))
        {
            var customers = CustomerCoverter.ConvertList(await _customerRepository.GetAllAsync(ct)).ToList();
            foreach (var customer in customers)
            {
                customer.Invoices = await GetInvoiceByCustomerIdAsync(customer.CustomerId, ct);
                customer.SupportRep = await GetEmployeeByIdAsync(customer.SupportRepId.GetValueOrDefault(), ct);
                customer.SupportRepName = $"{customer.SupportRep.LastName}, {customer.SupportRep.FirstName}";
            }
            return customers.ToList();
        }

        public async Task<CustomerViewModel> GetCustomerByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var customerViewModel = CustomerCoverter.Convert(await _customerRepository.GetByIdAsync(id, ct));
            customerViewModel.Invoices = await GetInvoiceByCustomerIdAsync(customerViewModel.CustomerId, ct);
            customerViewModel.SupportRep = await GetEmployeeByIdAsync(customerViewModel.SupportRepId.GetValueOrDefault(), ct);
            customerViewModel.SupportRepName = $"{customerViewModel.SupportRep.LastName}, {customerViewModel.SupportRep.FirstName}";
            return customerViewModel;
        }

        public async Task<List<CustomerViewModel>> GetCustomerBySupportRepIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var customers = await _customerRepository.GetBySupportRepIdAsync(id, ct);
            return CustomerCoverter.ConvertList(customers).ToList();
        }

        public async Task<CustomerViewModel> AddCustomerAsync(CustomerViewModel newCustomerViewModel, CancellationToken ct = default(CancellationToken))
        {
            var customer = new Customer
            {
                FirstName = newCustomerViewModel.FirstName,
                LastName = newCustomerViewModel.LastName,
                Company = newCustomerViewModel.Company,
                Address = newCustomerViewModel.Address,
                City = newCustomerViewModel.City,
                State = newCustomerViewModel.State,
                Country = newCustomerViewModel.Country,
                PostalCode = newCustomerViewModel.PostalCode,
                Phone = newCustomerViewModel.Phone,
                Fax = newCustomerViewModel.Fax,
                Email = newCustomerViewModel.Email,
                SupportRepId = newCustomerViewModel.SupportRepId
            };

            customer = await _customerRepository.AddAsync(customer, ct);
            newCustomerViewModel.CustomerId = customer.CustomerId;
            return newCustomerViewModel;
        }

        public async Task<bool> UpdateCustomerAsync(CustomerViewModel customerViewModel, CancellationToken ct = default(CancellationToken))
        {
            var customer = await _customerRepository.GetByIdAsync(customerViewModel.CustomerId, ct);

            if (customer == null) return false;
            customer.FirstName = customerViewModel.FirstName;
            customer.LastName = customerViewModel.LastName;
            customer.Company = customerViewModel.Company;
            customer.Address = customerViewModel.Address;
            customer.City = customerViewModel.City;
            customer.State = customerViewModel.State;
            customer.Country = customerViewModel.Country;
            customer.PostalCode = customerViewModel.PostalCode;
            customer.Phone = customerViewModel.Phone;
            customer.Fax = customerViewModel.Fax;
            customer.Email = customerViewModel.Email;
            customer.SupportRepId = customerViewModel.SupportRepId;
                
            return await _customerRepository.UpdateAsync(customer, ct);

        }

        public async Task<bool> DeleteCustomerAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _customerRepository.DeleteAsync(id, ct);
        }

        public async Task<List<EmployeeViewModel>> GetAllEmployeeAsync(CancellationToken ct = default(CancellationToken))
        {
            var employees = EmployeeCoverter.ConvertList(await _employeeRepository.GetAllAsync(ct));
            foreach (var employee in employees)
            {
                employee.Customers = await GetCustomerBySupportRepIdAsync(employee.EmployeeId, ct);
                employee.DirectReports = await GetEmployeeDirectReportsAsync(employee.EmployeeId, ct);
                employee.Manager = employee.ReportsTo.HasValue ? await GetEmployeeReportsToAsync(employee.ReportsTo.GetValueOrDefault(), ct) : null;
                employee.ReportsToName = employee.ReportsTo.HasValue ? $"{employee.Manager.LastName}, {employee.Manager.FirstName}" : string.Empty;
            }
            return employees.ToList();
        }

        public async Task<EmployeeViewModel> GetEmployeeByIdAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            var employeeViewModel = EmployeeCoverter.Convert(await _employeeRepository.GetByIdAsync(id, ct));
            employeeViewModel.Customers = await GetCustomerBySupportRepIdAsync(employeeViewModel.EmployeeId, ct);
            employeeViewModel.DirectReports = await GetEmployeeDirectReportsAsync(employeeViewModel.EmployeeId, ct);
            employeeViewModel.Manager = employeeViewModel.ReportsTo.HasValue ? await GetEmployeeReportsToAsync(employeeViewModel.ReportsTo.GetValueOrDefault(), ct) : null;
            employeeViewModel.ReportsToName = employeeViewModel.ReportsTo.HasValue ? $"{employeeViewModel.Manager.LastName}, {employeeViewModel.Manager.FirstName}" : string.Empty;
            return employeeViewModel;
        }

        public async Task<EmployeeViewModel> GetEmployeeReportsToAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            var employee = await _employeeRepository.GetReportsToAsync(id, ct);
            return EmployeeCoverter.Convert(employee);
        }

        public async Task<EmployeeViewModel> AddEmployeeAsync(EmployeeViewModel newEmployeeViewModel, CancellationToken ct = default(CancellationToken))
        {
            var employee = new Employee
            {
                LastName = newEmployeeViewModel.LastName,
                FirstName = newEmployeeViewModel.FirstName,
                Title = newEmployeeViewModel.Title,
                ReportsTo = newEmployeeViewModel.ReportsTo,
                BirthDate = newEmployeeViewModel.BirthDate,
                HireDate = newEmployeeViewModel.HireDate,
                Address = newEmployeeViewModel.Address,
                City = newEmployeeViewModel.City,
                State = newEmployeeViewModel.State,
                Country = newEmployeeViewModel.Country,
                PostalCode = newEmployeeViewModel.PostalCode,
                Phone = newEmployeeViewModel.Phone,
                Fax = newEmployeeViewModel.Fax,
                Email = newEmployeeViewModel.Email
            };

            employee = await _employeeRepository.AddAsync(employee, ct);
            newEmployeeViewModel.EmployeeId = employee.EmployeeId;
            return newEmployeeViewModel;
        }

        public async Task<bool> UpdateEmployeeAsync(EmployeeViewModel employeeViewModel, CancellationToken ct = default(CancellationToken))
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeViewModel.EmployeeId, ct);

            if (employee == null) return false;
            employee.EmployeeId = employeeViewModel.EmployeeId;
            employee.LastName = employeeViewModel.LastName;
            employee.FirstName = employeeViewModel.FirstName;
            employee.Title = employeeViewModel.Title;
            employee.ReportsTo = employeeViewModel.ReportsTo;
            employee.BirthDate = employeeViewModel.BirthDate;
            employee.HireDate = employeeViewModel.HireDate;
            employee.Address = employeeViewModel.Address;
            employee.City = employeeViewModel.City;
            employee.State = employeeViewModel.State;
            employee.Country = employeeViewModel.Country;
            employee.PostalCode = employeeViewModel.PostalCode;
            employee.Phone = employeeViewModel.Phone;
            employee.Fax = employeeViewModel.Fax;
            employee.Email = employeeViewModel.Email;
                
            return await _employeeRepository.UpdateAsync(employee, ct);

        }

        public async Task<bool> DeleteEmployeeAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _employeeRepository.DeleteAsync(id, ct);
        }

        public async Task<List<EmployeeViewModel>> GetEmployeeDirectReportsAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var employees = await _employeeRepository.GetDirectReportsAsync(id, ct);
            return EmployeeCoverter.ConvertList(employees).ToList();
        }

        public async Task<List<EmployeeViewModel>> GetDirectReportsAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var employees = await _employeeRepository.GetDirectReportsAsync(id, ct);
            return EmployeeCoverter.ConvertList(employees).ToList();
        }

        public async Task<List<GenreViewModel>> GetAllGenreAsync(CancellationToken ct = default(CancellationToken))
        {
            var genres = GenreCoverter.ConvertList(await _genreRepository.GetAllAsync(ct));
            foreach (var genre in genres)
            {
                genre.Tracks = await GetTrackByGenreIdAsync(genre.GenreId, ct);
            }
            return genres.ToList();
        }

        public async Task<GenreViewModel> GetGenreByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var genreViewModel = GenreCoverter.Convert(await _genreRepository.GetByIdAsync(id, ct));
            genreViewModel.Tracks = await GetTrackByGenreIdAsync(genreViewModel.GenreId, ct);
            return genreViewModel;
        }

        public async Task<GenreViewModel> AddGenreAsync(GenreViewModel newGenreViewModel, CancellationToken ct = default(CancellationToken))
        {
            var genre = new Genre
            {
                Name = newGenreViewModel.Name
            };

            genre = await _genreRepository.AddAsync(genre, ct);
            newGenreViewModel.GenreId = genre.GenreId;
            return newGenreViewModel;
        }

        public async Task<bool> UpdateGenreAsync(GenreViewModel genreViewModel, CancellationToken ct = default(CancellationToken))
        {
            var genre = await _genreRepository.GetByIdAsync(genreViewModel.GenreId, ct);

            if (genre == null) return false;
            genre.GenreId = genreViewModel.GenreId;
            genre.Name = genreViewModel.Name;
                
            return await _genreRepository.UpdateAsync(genre, ct);

        }

        public async Task<bool> DeleteGenreAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _genreRepository.DeleteAsync(id, ct);
        }

        public async Task<List<InvoiceLineViewModel>> GetAllInvoiceLineAsync(CancellationToken ct = default(CancellationToken))
        {
            var invoiceLines = InvoiceLineCoverter.ConvertList(await _invoiceLineRepository.GetAllAsync(ct));
            /*foreach (var invoiceLine in invoiceLines)
            {
                invoiceLine.Track = await GetTrackByIdAsync(invoiceLine.TrackId, ct);
                invoiceLine.Invoice = await GetInvoiceByIdAsync(invoiceLine.InvoiceId, ct);
                invoiceLine.TrackName = invoiceLine.Track.Name;
            }*/
            return invoiceLines.ToList();
        }

        public async Task<InvoiceLineViewModel> GetInvoiceLineByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var invoiceLineViewModel = InvoiceLineCoverter.Convert(await _invoiceLineRepository.GetByIdAsync(id, ct));
            invoiceLineViewModel.Track = await GetTrackByIdAsync(invoiceLineViewModel.TrackId, ct);
            invoiceLineViewModel.Invoice = await GetInvoiceByIdAsync(invoiceLineViewModel.InvoiceId, ct);
            invoiceLineViewModel.TrackName = invoiceLineViewModel.Track.Name;
            return invoiceLineViewModel;
        }

        public async Task<List<InvoiceLineViewModel>> GetInvoiceLineByInvoiceIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var invoiceLines = await _invoiceLineRepository.GetByInvoiceIdAsync(id, ct);
            return InvoiceLineCoverter.ConvertList(invoiceLines).ToList();
        }

        public async Task<List<InvoiceLineViewModel>> GetInvoiceLineByTrackIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var invoiceLines = await _invoiceLineRepository.GetByTrackIdAsync(id, ct);
            return InvoiceLineCoverter.ConvertList(invoiceLines).ToList();
        }

        public async Task<InvoiceLineViewModel> AddInvoiceLineAsync(InvoiceLineViewModel newInvoiceLineViewModel, CancellationToken ct = default(CancellationToken))
        {
            var invoiceLine = new InvoiceLine
            {
                InvoiceId = newInvoiceLineViewModel.InvoiceId,
                TrackId = newInvoiceLineViewModel.TrackId,
                UnitPrice = newInvoiceLineViewModel.UnitPrice,
                Quantity = newInvoiceLineViewModel.Quantity
            };

            invoiceLine = await _invoiceLineRepository.AddAsync(invoiceLine, ct);
            newInvoiceLineViewModel.InvoiceLineId = invoiceLine.InvoiceLineId;
            return newInvoiceLineViewModel;
        }

        public async Task<bool> UpdateInvoiceLineAsync(InvoiceLineViewModel invoiceLineViewModel, CancellationToken ct = default(CancellationToken))
        {
            var invoiceLine = await _invoiceLineRepository.GetByIdAsync(invoiceLineViewModel.InvoiceId, ct);

            if (invoiceLine == null) return false;
            invoiceLine.InvoiceLineId = invoiceLineViewModel.InvoiceLineId;
            invoiceLine.InvoiceId = invoiceLineViewModel.InvoiceId;
            invoiceLine.TrackId = invoiceLineViewModel.TrackId;
            invoiceLine.UnitPrice = invoiceLineViewModel.UnitPrice;
            invoiceLine.Quantity = invoiceLineViewModel.Quantity;
                
            return await _invoiceLineRepository.UpdateAsync(invoiceLine, ct);

        }

        public async Task<bool> DeleteInvoiceLineAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _invoiceLineRepository.DeleteAsync(id, ct);
        }

        public async Task<List<InvoiceViewModel>> GetAllInvoiceAsync(CancellationToken ct = default(CancellationToken))
        {
            var invoices = InvoiceCoverter.ConvertList(await _invoiceRepository.GetAllAsync(ct));
            foreach (var invoice in invoices)
            {
                invoice.Customer = await GetCustomerByIdAsync(invoice.CustomerId, ct);
                invoice.InvoiceLines = await GetInvoiceLineByInvoiceIdAsync(invoice.InvoiceId, ct);
                invoice.CustomerName = $"{invoice.Customer.LastName}, {invoice.Customer.FirstName}";
            }
            return invoices.ToList();
        }

        public async Task<InvoiceViewModel> GetInvoiceByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var invoiceViewModel = InvoiceCoverter.Convert(await _invoiceRepository.GetByIdAsync(id, ct));
            invoiceViewModel.Customer = await GetCustomerByIdAsync(invoiceViewModel.CustomerId, ct);
            invoiceViewModel.InvoiceLines = await GetInvoiceLineByInvoiceIdAsync(invoiceViewModel.InvoiceId, ct);
            invoiceViewModel.CustomerName = $"{invoiceViewModel.Customer.LastName}, {invoiceViewModel.Customer.FirstName}";
            return invoiceViewModel;
        }

        public async Task<List<InvoiceViewModel>> GetInvoiceByCustomerIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var invoices = await _invoiceRepository.GetByCustomerIdAsync(id, ct);
            return InvoiceCoverter.ConvertList(invoices).ToList();
        }

        public async Task<InvoiceViewModel> AddInvoiceAsync(InvoiceViewModel newInvoiceViewModel, CancellationToken ct = default(CancellationToken))
        {
            var invoice = new Invoice
            {
                CustomerId = newInvoiceViewModel.CustomerId,
                InvoiceDate = newInvoiceViewModel.InvoiceDate,
                BillingAddress = newInvoiceViewModel.BillingAddress,
                BillingCity = newInvoiceViewModel.BillingCity,
                BillingState = newInvoiceViewModel.BillingState,
                BillingCountry = newInvoiceViewModel.BillingCountry,
                BillingPostalCode = newInvoiceViewModel.BillingPostalCode,
                Total = newInvoiceViewModel.Total
            };

            invoice = await _invoiceRepository.AddAsync(invoice, ct);
            newInvoiceViewModel.InvoiceId = invoice.InvoiceId;
            return newInvoiceViewModel;
        }

        public async Task<bool> UpdateInvoiceAsync(InvoiceViewModel invoiceViewModel, CancellationToken ct = default(CancellationToken))
        {
            var invoice = await _invoiceRepository.GetByIdAsync(invoiceViewModel.InvoiceId, ct);

            if (invoice == null) return false;
            invoice.InvoiceId = invoiceViewModel.InvoiceId;
            invoice.CustomerId = invoiceViewModel.CustomerId;
            invoice.InvoiceDate = invoiceViewModel.InvoiceDate;
            invoice.BillingAddress = invoiceViewModel.BillingAddress;
            invoice.BillingCity = invoiceViewModel.BillingCity;
            invoice.BillingState = invoiceViewModel.BillingState;
            invoice.BillingCountry = invoiceViewModel.BillingCountry;
            invoice.BillingPostalCode = invoiceViewModel.BillingPostalCode;
            invoice.Total = invoiceViewModel.Total;
                
            return await _invoiceRepository.UpdateAsync(invoice, ct);

        }

        public async Task<bool> DeleteInvoiceAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _invoiceRepository.DeleteAsync(id, ct);
        }

        public async Task<List<MediaTypeViewModel>> GetAllMediaTypeAsync(CancellationToken ct = default(CancellationToken))
        {
            var mediaTypes = MediaTypeCoverter.ConvertList(await _mediaTypeRepository.GetAllAsync(ct));
            foreach (var mediaType in mediaTypes)
            {
                mediaType.Tracks = await GetTrackByMediaTypeIdAsync(mediaType.MediaTypeId, ct);
            }
            return mediaTypes.ToList();
        }

        public async Task<MediaTypeViewModel> GetMediaTypeByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var mediaTypeViewModel = MediaTypeCoverter.Convert(await _mediaTypeRepository.GetByIdAsync(id, ct));
            mediaTypeViewModel.Tracks = await GetTrackByMediaTypeIdAsync(mediaTypeViewModel.MediaTypeId, ct);
            return mediaTypeViewModel;
        }

        public async Task<MediaTypeViewModel> AddMediaTypeAsync(MediaTypeViewModel newMediaTypeViewModel, CancellationToken ct = default(CancellationToken))
        {
            var mediaType = new MediaType
            {
                Name = newMediaTypeViewModel.Name
            };

            mediaType = await _mediaTypeRepository.AddAsync(mediaType, ct);
            newMediaTypeViewModel.MediaTypeId = mediaType.MediaTypeId;
            return newMediaTypeViewModel;
        }

        public async Task<bool> UpdateMediaTypeAsync(MediaTypeViewModel mediaTypeViewModel, CancellationToken ct = default(CancellationToken))
        {
            var  mediaType = await _mediaTypeRepository.GetByIdAsync( mediaTypeViewModel.MediaTypeId, ct);

            if (mediaType == null) return false;
            mediaType.MediaTypeId = mediaTypeViewModel.MediaTypeId;
            mediaType.Name = mediaTypeViewModel.Name;
                
            return await _mediaTypeRepository.UpdateAsync( mediaType, ct);

        }

        public async Task<bool> DeleteMediaTypeAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _mediaTypeRepository.DeleteAsync(id, ct);
        }

        public async Task<List<PlaylistViewModel>> GetAllPlaylistAsync(CancellationToken ct = default(CancellationToken))
        {
            var playlists = PlaylistCoverter.ConvertList(await _playlistRepository.GetAllAsync(ct));
            foreach (var playlist in playlists)
            {
                playlist.Tracks = await GetTrackByPlaylistIdIdAsync(playlist.PlaylistId, ct);
            }
            return playlists.ToList();
        }

        public async Task<PlaylistViewModel> GetPlaylistByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var playlistViewModel = PlaylistCoverter.Convert(await _playlistRepository.GetByIdAsync(id, ct));
            playlistViewModel.Tracks = await GetTrackByPlaylistIdIdAsync(playlistViewModel.PlaylistId, ct);
            return playlistViewModel;
        }

        public async Task<PlaylistViewModel> AddPlaylistAsync(PlaylistViewModel newPlaylistViewModel, CancellationToken ct = default(CancellationToken))
        {
            var playlist = new Playlist
            {
                Name = newPlaylistViewModel.Name
            };

            playlist = await _playlistRepository.AddAsync(playlist, ct);
            newPlaylistViewModel.PlaylistId = playlist.PlaylistId;
            return newPlaylistViewModel;
        }

        public async Task<bool> UpdatePlaylistAsync(PlaylistViewModel playlistViewModel, CancellationToken ct = default(CancellationToken))
        {
            var playlist = await _playlistRepository.GetByIdAsync(playlistViewModel.PlaylistId, ct);

            if (playlist == null) return false;
            playlist.PlaylistId = playlistViewModel.PlaylistId;
            playlist.Name = playlistViewModel.Name;
                
            return await _playlistRepository.UpdateAsync(playlist, ct);

        }

        public async Task<bool> DeletePlaylistAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _playlistRepository.DeleteAsync(id, ct);
        }

        public async Task<List<TrackViewModel>> GetAllTrackAsync(CancellationToken ct = default(CancellationToken))
        {
            var tracks = TrackCoverter.ConvertList(await _trackRepository.GetAllAsync(ct));
            /*foreach (var track in tracks)
            {
                track.Genre = await GetGenreByIdAsync(track.GenreId.GetValueOrDefault(), ct);
                track.Album = await GetAlbumByIdAsync(track.AlbumId, ct);
                track.MediaType = await GetMediaTypeByIdAsync(track.MediaTypeId, ct);
                track.AlbumName = track.Album.Title;
                track.MediaTypeName = track.MediaType.Name;
                track.GenreName = track.Genre.Name;
            }*/
            return tracks.ToList();
        }

        public async Task<TrackViewModel> GetTrackByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var trackViewModel = TrackCoverter.Convert(await _trackRepository.GetByIdAsync(id, ct));
            trackViewModel.Genre = await GetGenreByIdAsync(trackViewModel.GenreId.GetValueOrDefault(), ct);
            trackViewModel.Album = await GetAlbumByIdAsync(trackViewModel.AlbumId, ct);
            trackViewModel.MediaType = await GetMediaTypeByIdAsync(trackViewModel.MediaTypeId, ct);
            trackViewModel.AlbumName = trackViewModel.Album.Title;
            trackViewModel.MediaTypeName = trackViewModel.MediaType.Name;
            trackViewModel.GenreName = trackViewModel.Genre.Name;
            return trackViewModel;
        }

        public async Task<List<TrackViewModel>> GetTrackByAlbumIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var tracks = await _trackRepository.GetByAlbumIdAsync(id, ct);
            return TrackCoverter.ConvertList(tracks).ToList();
        }

        public async Task<List<TrackViewModel>> GetTrackByGenreIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var tracks = await _trackRepository.GetByGenreIdAsync(id, ct);
            return TrackCoverter.ConvertList(tracks).ToList();
        }

        public async Task<List<TrackViewModel>> GetTrackByMediaTypeIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var tracks = await _trackRepository.GetByMediaTypeIdAsync(id, ct);
            return TrackCoverter.ConvertList(tracks).ToList();
        }
        
        public async Task<List<TrackViewModel>> GetTrackByPlaylistIdIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var tracks = await _playlistRepository.GetTrackByPlaylistIdAsync(id, ct);
            return TrackCoverter.ConvertList(tracks).ToList();
        }

        public async Task<TrackViewModel> AddTrackAsync(TrackViewModel newTrackViewModel, CancellationToken ct = default(CancellationToken))
        {
            var track = new Track
            {
                TrackId = newTrackViewModel.TrackId,
                Name = newTrackViewModel.Name,
                AlbumId = newTrackViewModel.AlbumId,
                MediaTypeId = newTrackViewModel.MediaTypeId,
                GenreId = newTrackViewModel.GenreId,
                Composer = newTrackViewModel.Composer,
                Milliseconds = newTrackViewModel.Milliseconds,
                Bytes = newTrackViewModel.Bytes,
                UnitPrice = newTrackViewModel.UnitPrice
            };

            await _trackRepository.AddAsync(track, ct);
            newTrackViewModel.TrackId = track.TrackId;
            return newTrackViewModel;
        }

        public async Task<bool> UpdateTrackAsync(TrackViewModel trackViewModel, CancellationToken ct = default(CancellationToken))
        {
            var track = await _trackRepository.GetByIdAsync(trackViewModel.TrackId, ct);

            if (track == null) return false;
            track.TrackId = trackViewModel.TrackId;
            track.Name = trackViewModel.Name;
            track.AlbumId = trackViewModel.AlbumId;
            track.MediaTypeId = trackViewModel.MediaTypeId;
            track.GenreId = trackViewModel.GenreId;
            track.Composer = trackViewModel.Composer;
            track.Milliseconds = trackViewModel.Milliseconds;
            track.Bytes = trackViewModel.Bytes;
            track.UnitPrice = trackViewModel.UnitPrice;
                
            return await _trackRepository.UpdateAsync(track, ct);

        }

        public async Task<bool> DeleteTrackAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _trackRepository.DeleteAsync(id, ct);
        }
    }
}