using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chinook.DataEFCoreCmpldQry.Configurations;
using Chinook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chinook.DataEFCoreCmpldQry
{
    public class ChinookContext : DbContext
    {
        public static long InstanceCount;

        private static readonly Func<ChinookContext, Task<List<Album>>> _queryGetAllAlbums =
            EF.CompileAsyncQuery((ChinookContext db) =>
                db.Album.ToList());

        private static readonly Func<ChinookContext, int, Task<Album>> _queryGetAlbum =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Album.Find(id));

        private static readonly Func<ChinookContext, int, Task<List<Album>>> _queryGetAlbumsByArtistId =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Album.Where(a => a.ArtistId == id).ToList());

        private static readonly Func<ChinookContext, Task<List<Artist>>> _queryGetAllArtists =
            EF.CompileAsyncQuery((ChinookContext db) =>
                db.Artist.ToList());

        private static readonly Func<ChinookContext, int, Task<Artist>> _queryGetArtist =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Artist.Find(id));

        private static readonly Func<ChinookContext, Task<List<Customer>>> _queryGetAllCustomers =
            EF.CompileAsyncQuery((ChinookContext db) =>
                db.Customer.ToList());

        private static readonly Func<ChinookContext, int, Task<Customer>> _queryGetCustomer =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Customer.Find(id));

        private static readonly Func<ChinookContext, int, Task<List<Customer>>> _queryGetCustomerBySupportRepId =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Customer.Where(a => a.SupportRepId == id).ToList());

        private static readonly Func<ChinookContext, Task<List<Employee>>> _queryGetAllEmployees =
            EF.CompileAsyncQuery((ChinookContext db) =>
                db.Employee.ToList());

        private static readonly Func<ChinookContext, int, Task<Employee>> _queryGetEmployee =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Employee.Find(id));

        private static readonly Func<ChinookContext, int, Task<List<Employee>>> _queryGetDirectReports =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Employee.Where(e => e.ReportsTo == id).ToList());

        private static readonly Func<ChinookContext, int, Task<Employee>> _queryGetReportsTo =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Employee.Find(id));

        private static readonly Func<ChinookContext, Task<List<Genre>>> _queryGetAllGenres =
            EF.CompileAsyncQuery((ChinookContext db) =>
                db.Genre.ToList());

        private static readonly Func<ChinookContext, int, Task<Genre>> _queryGetGenre =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Genre.Find(id));

        private static readonly Func<ChinookContext, Task<List<InvoiceLine>>> _queryGetAllInvoiceLines =
            EF.CompileAsyncQuery((ChinookContext db) =>
                db.InvoiceLine.ToList());

        private static readonly Func<ChinookContext, int, Task<InvoiceLine>> _queryGetInvoiceLine =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.InvoiceLine.Find(id));

        private static readonly Func<ChinookContext, int, Task<List<InvoiceLine>>> _queryGetInvoiceLinesByInvoiceId =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.InvoiceLine.Where(a => a.InvoiceId == id).ToList());

        private static readonly Func<ChinookContext, int, Task<List<InvoiceLine>>> _queryGetInvoiceLinesByTrackId =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.InvoiceLine.Where(a => a.TrackId == id).ToList());

        private static readonly Func<ChinookContext, Task<List<Invoice>>> _queryGetAllInvoices =
            EF.CompileAsyncQuery((ChinookContext db) =>
                db.Invoice.ToList());

        private static readonly Func<ChinookContext, int, Task<Invoice>> _queryGetInvoice =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Invoice.Find(id));

        private static readonly Func<ChinookContext, int, Task<List<Invoice>>> _queryGetInvoicesByCustomerId =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Invoice.Where(a => a.CustomerId == id).ToList());

        private static readonly Func<ChinookContext, Task<List<MediaType>>> _queryGetAllMediaTypes =
            EF.CompileAsyncQuery((ChinookContext db) =>
                db.MediaType.ToList());

        private static readonly Func<ChinookContext, int, Task<MediaType>> _queryGetMediaType =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.MediaType.Find(id));

        private static readonly Func<ChinookContext, Task<List<Playlist>>> _queryGetAllPlaylists =
            EF.CompileAsyncQuery((ChinookContext db) =>
                db.Playlist.ToList());

        private static readonly Func<ChinookContext, int, Task<Playlist>> _queryGetPlaylist =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Playlist.Find(id));

        private static readonly Func<ChinookContext, Task<List<PlaylistTrack>>>
            _queryGetAllPlaylistTracks =
                EF.CompileAsyncQuery((ChinookContext db) =>
                    db.PlaylistTrack.ToList());

        private static readonly Func<ChinookContext, int, Task<List<PlaylistTrack>>>
            _queryGetPlaylistTrackByPlaylistId =
                EF.CompileAsyncQuery((ChinookContext db, int id) =>
                    db.PlaylistTrack.Where(a => a.PlaylistId == id).ToList());

        private static readonly Func<ChinookContext, int, Task<List<PlaylistTrack>>> _queryGetPlaylistTracksByTrackId =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.PlaylistTrack.Where(a => a.TrackId == id).ToList());

        private static readonly Func<ChinookContext, Task<List<Track>>> _queryGetAllTracks =
            EF.CompileAsyncQuery((ChinookContext db) =>
                db.Track.ToList());

        private static readonly Func<ChinookContext, int, Task<Track>> _queryGetTrack =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Track.Find(id));

        private static readonly Func<ChinookContext, int, Task<List<Track>>> _queryGetTracksByAlbumId =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Track.Where(a => a.AlbumId == id).ToList());

        private static readonly Func<ChinookContext, int, Task<List<Track>>> _queryGetTracksByGenreId =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Track.Where(a => a.GenreId == id).ToList());

        private static readonly Func<ChinookContext, int, Task<List<Track>>> _queryGetTracksByMediaTypeId =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Track.Where(a => a.MediaTypeId == id).ToList());

        public ChinookContext(DbContextOptions options) : base(options)
        {
            Interlocked.Increment(ref InstanceCount);
        }

        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceLine> InvoiceLine { get; set; }
        public virtual DbSet<MediaType> MediaType { get; set; }
        public virtual DbSet<Playlist> Playlist { get; set; }
        public virtual DbSet<PlaylistTrack> PlaylistTrack { get; set; }
        public virtual DbSet<Track> Track { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AlbumConfiguration(modelBuilder.Entity<Album>());
            new ArtistConfiguration(modelBuilder.Entity<Artist>());
            new CustomerConfiguration(modelBuilder.Entity<Customer>());
            new EmployeeConfiguration(modelBuilder.Entity<Employee>());
            new GenreConfiguration(modelBuilder.Entity<Genre>());
            new InvoiceConfiguration(modelBuilder.Entity<Invoice>());
            new InvoiceLineConfiguration(modelBuilder.Entity<InvoiceLine>());
            new MediaTypeConfiguration(modelBuilder.Entity<MediaType>());
            new PlaylistConfiguration(modelBuilder.Entity<Playlist>());
            new PlaylistTrackConfiguration(modelBuilder.Entity<PlaylistTrack>());
            new TrackConfiguration(modelBuilder.Entity<Track>());
        }

        public async Task<List<Album>> GetAllAlbumsAsync()
        {
            return await _queryGetAllAlbums(this);
        }

        public async Task<Album> GetAlbumAsync(int id)
        {
            return await _queryGetAlbum(this, id);
        }

        public async Task<List<Album>> GetAlbumsByArtistIdAsync(int id)
        {
            return await _queryGetAlbumsByArtistId(this, id);
        }

        public async Task<List<Artist>> GetAllArtistsAsync()
        {
            return await _queryGetAllArtists(this);
        }

        public async Task<Artist> GetArtistAsync(int id)
        {
            return await _queryGetArtist(this, id);
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _queryGetAllCustomers(this);
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await _queryGetCustomer(this, id);
        }

        public async Task<List<Customer>> GetCustomerBySupportRepIdAsync(int id)
        {
            return await _queryGetCustomerBySupportRepId(this, id);
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _queryGetAllEmployees(this);
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return await _queryGetEmployee(this, id);
        }

        public async Task<List<Employee>> GetEmployeeDirectReportsAsync(int id)
        {
            return await _queryGetDirectReports(this, id);
        }

        public async Task<Employee> GetEmployeeGetReportsToAsync(int id)
        {
            return await _queryGetReportsTo(this, id);
        }

        public async Task<List<Genre>> GetAllGenresAsync()
        {
            return await _queryGetAllGenres(this);
        }

        public async Task<Genre> GetGenreAsync(int id)
        {
            return await _queryGetGenre(this, id);
        }

        public async Task<List<InvoiceLine>> GetAllInvoiceLinesAsync()
        {
            return await _queryGetAllInvoiceLines(this);
        }

        public async Task<InvoiceLine> GetInvoiceLineAsync(int id)
        {
            return await _queryGetInvoiceLine(this, id);
        }

        public async Task<List<InvoiceLine>> GetInvoiceLinesByInvoiceIdAsync(int id)
        {
            return await _queryGetInvoiceLinesByInvoiceId(this, id);
        }

        public async Task<List<InvoiceLine>> GetInvoiceLinesByTrackIdAsync(int id)
        {
            return await _queryGetInvoiceLinesByTrackId(this, id);
        }

        public async Task<List<Invoice>> GetAllInvoicesAsync()
        {
            return await _queryGetAllInvoices(this);
        }

        public async Task<Invoice> GetInvoiceAsync(int id)
        {
            return await _queryGetInvoice(this, id);
        }

        public async Task<List<Invoice>> GetInvoicesByCustomerIdAsync(int id)
        {
            return await _queryGetInvoicesByCustomerId(this, id);
        }

        public async Task<List<MediaType>> GetAllMediaTypesAsync()
        {
            return await _queryGetAllMediaTypes(this);
        }

        public async Task<MediaType> GetMediaTypeAsync(int id)
        {
            return await _queryGetMediaType(this, id);
        }

        public async Task<List<Playlist>> GetAllPlaylistsAsync()
        {
            return await _queryGetAllPlaylists(this);
        }

        public async Task<Playlist> GetPlaylistAsync(int id)
        {
            return await _queryGetPlaylist(this, id);
        }

        public async Task<List<PlaylistTrack>> GetAllPlaylistTracksAsync()
        {
            return await _queryGetAllPlaylistTracks(this);
        }

        public async Task<List<PlaylistTrack>> GetPlaylistTrackByPlaylistId(int id)
        {
            return await _queryGetPlaylistTrackByPlaylistId(this, id);
        }

        public async Task<List<PlaylistTrack>> GetPlaylistTracksByTrackIdAsync(int id)
        {
            return await _queryGetPlaylistTracksByTrackId(this, id);
        }

        public async Task<List<Track>> GetAllTracksAsync()
        {
            return await _queryGetAllTracks(this);
        }

        public async Task<Track> GetTrackAsync(int id)
        {
            return await _queryGetTrack(this, id);
        }

        public async Task<List<Track>> GetTracksByAlbumIdAsync(int id)
        {
            return await _queryGetTracksByAlbumId(this, id);
        }

        public async Task<List<Track>> GetTracksByGenreIdAsync(int id)
        {
            return await _queryGetTracksByGenreId(this, id);
        }

        public async Task<List<Track>> GetTracksByMediaTypeIdAsync(int id)
        {
            return await _queryGetTracksByMediaTypeId(this, id);
        }
    }
}