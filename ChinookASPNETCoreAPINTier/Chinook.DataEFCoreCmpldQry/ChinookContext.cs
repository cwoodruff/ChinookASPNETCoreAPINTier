using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chinook.DataEFCoreCmpldQry.Configurations;
using Chinook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Chinook.DataEFCoreCmpldQry
{
    public class ChinookContext : DbContext
    {
        public static long InstanceCount;

        private static readonly Func<ChinookContext, AsyncEnumerable<Album>> _queryGetAllAlbums =
            EF.CompileAsyncQuery((ChinookContext db) => db.Album);

        private static readonly Func<ChinookContext, int, AsyncEnumerable<Album>> _queryGetAlbum =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Album.Where( a => a.AlbumId == id));
        
        private static readonly Func<ChinookContext, int, AsyncEnumerable<Album>> _queryGetAlbumsByArtistId =
            EF.CompileAsyncQuery((ChinookContext db, int id) => db.Album.Where(a => a.ArtistId == id));

        private static readonly Func<ChinookContext, AsyncEnumerable<Artist>> _queryGetAllArtists =
            EF.CompileAsyncQuery((ChinookContext db) => db.Artist);

        private static readonly Func<ChinookContext, int, AsyncEnumerable<Artist>> _queryGetArtist =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Artist.Where(a => a.ArtistId == id));

        private static readonly Func<ChinookContext, AsyncEnumerable<Customer>> _queryGetAllCustomers =
            EF.CompileAsyncQuery((ChinookContext db) => db.Customer);

        private static readonly Func<ChinookContext, int, AsyncEnumerable<Customer>> _queryGetCustomer =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Customer.Where(c => c.CustomerId == id));

        private static readonly Func<ChinookContext, int, AsyncEnumerable<Customer>> _queryGetCustomerBySupportRepId =
            EF.CompileAsyncQuery((ChinookContext db, int id) => db.Customer.Where(a => a.SupportRepId == id));

        private static readonly Func<ChinookContext, AsyncEnumerable<Employee>> _queryGetAllEmployees =
            EF.CompileAsyncQuery((ChinookContext db) => db.Employee);

        private static readonly Func<ChinookContext, int, AsyncEnumerable<Employee>> _queryGetEmployee =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Employee.Where(e => e.EmployeeId == id));

        private static readonly Func<ChinookContext, int, AsyncEnumerable<Employee>> _queryGetDirectReports =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Employee.Where(e => e.ReportsTo == id));

        private static readonly Func<ChinookContext, int, AsyncEnumerable<Employee>> _queryGetReportsTo =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Employee.Where(e => e.ReportsTo == id));

        private static readonly Func<ChinookContext, AsyncEnumerable<Genre>> _queryGetAllGenres =
            EF.CompileAsyncQuery((ChinookContext db) => db.Genre);

        private static readonly Func<ChinookContext, int, AsyncEnumerable<Genre>> _queryGetGenre =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Genre.Where( g => g.GenreId == id));

        private static readonly Func<ChinookContext, AsyncEnumerable<InvoiceLine>> _queryGetAllInvoiceLines =
            EF.CompileAsyncQuery((ChinookContext db) =>db.InvoiceLine);

        private static readonly Func<ChinookContext, int, AsyncEnumerable<InvoiceLine>> _queryGetInvoiceLine =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.InvoiceLine.Where( i => i.InvoiceLineId == id));

        private static readonly Func<ChinookContext, int, AsyncEnumerable<InvoiceLine>> _queryGetInvoiceLinesByInvoiceId =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.InvoiceLine.Where(a => a.InvoiceId == id));

        private static readonly Func<ChinookContext, int, AsyncEnumerable<InvoiceLine>> _queryGetInvoiceLinesByTrackId =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.InvoiceLine.Where(a => a.TrackId == id));

        private static readonly Func<ChinookContext, AsyncEnumerable<Invoice>> _queryGetAllInvoices =
            EF.CompileAsyncQuery((ChinookContext db) => db.Invoice);

        private static readonly Func<ChinookContext, int, AsyncEnumerable<Invoice>> _queryGetInvoice =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Invoice.Where(i => i.InvoiceId == id));

        private static readonly Func<ChinookContext, int, AsyncEnumerable<Invoice>> _queryGetInvoicesByCustomerId =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Invoice.Where(a => a.CustomerId == id));

        private static readonly Func<ChinookContext, AsyncEnumerable<MediaType>> _queryGetAllMediaTypes =
            EF.CompileAsyncQuery((ChinookContext db) =>
                db.MediaType);

        private static readonly Func<ChinookContext, int, AsyncEnumerable<MediaType>> _queryGetMediaType =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.MediaType.Where( m => m.MediaTypeId == id));

        private static readonly Func<ChinookContext, AsyncEnumerable<Playlist>> _queryGetAllPlaylists =
            EF.CompileAsyncQuery((ChinookContext db) =>
                db.Playlist);

        private static readonly Func<ChinookContext, int, AsyncEnumerable<Playlist>> _queryGetPlaylist =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Playlist.Where( p => p.PlaylistId == id));

        private static readonly Func<ChinookContext, AsyncEnumerable<PlaylistTrack>> _queryGetAllPlaylistTracks =
                EF.CompileAsyncQuery((ChinookContext db) =>
                    db.PlaylistTrack);

        private static readonly Func<ChinookContext, int, AsyncEnumerable<PlaylistTrack>> _queryGetPlaylistTrackByPlaylistId =
                EF.CompileAsyncQuery((ChinookContext db, int id) =>
                    db.PlaylistTrack.Where(a => a.PlaylistId == id));

        private static readonly Func<ChinookContext, int, AsyncEnumerable<PlaylistTrack>> _queryGetPlaylistTracksByTrackId =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.PlaylistTrack.Where(a => a.TrackId == id));

        private static readonly Func<ChinookContext, AsyncEnumerable<Track>> _queryGetAllTracks =
            EF.CompileAsyncQuery((ChinookContext db) =>
                db.Track);

        private static readonly Func<ChinookContext, int, AsyncEnumerable<Track>> _queryGetTrack =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Track.Where(t=> t.TrackId == id));

        private static readonly Func<ChinookContext, int, AsyncEnumerable<Track>> _queryGetTracksByAlbumId =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Track.Where(a => a.AlbumId == id));

        private static readonly Func<ChinookContext, int, AsyncEnumerable<Track>> _queryGetTracksByGenreId =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Track.Where(a => a.GenreId == id));

        private static readonly Func<ChinookContext, int, AsyncEnumerable<Track>> _queryGetTracksByMediaTypeId =
            EF.CompileAsyncQuery((ChinookContext db, int id) =>
                db.Track.Where(a => a.MediaTypeId == id));

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

        public async Task<List<Album>> GetAllAlbumsAsync() => await _queryGetAllAlbums(this).ToListAsync();

        public async Task<List<Album>> GetAlbumAsync(int id) => await _queryGetAlbum(this, id).ToListAsync();

        public async Task<List<Album>> GetAlbumsByArtistIdAsync(int id) => await _queryGetAlbumsByArtistId(this, id).ToListAsync();

        public async Task<List<Artist>> GetAllArtistsAsync() => await _queryGetAllArtists(this).ToListAsync();

        public async Task<List<Artist>> GetArtistAsync(int id) => await _queryGetArtist(this, id).ToListAsync();

        public async Task<List<Customer>> GetAllCustomersAsync() => await _queryGetAllCustomers(this).ToListAsync();

        public async Task<List<Customer>> GetCustomerAsync(int id) => await _queryGetCustomer(this, id).ToListAsync();

        public async Task<List<Customer>> GetCustomerBySupportRepIdAsync(int id) => await _queryGetCustomerBySupportRepId(this, id).ToListAsync();

        public async Task<List<Employee>> GetAllEmployeesAsync() => await _queryGetAllEmployees(this).ToListAsync();

        public async Task<List<Employee>> GetEmployeeAsync(int id) => await _queryGetEmployee(this, id).ToListAsync();

        public async Task<List<Employee>> GetEmployeeDirectReportsAsync(int id) => await _queryGetDirectReports(this, id).ToListAsync();

        public async Task<List<Employee>> GetEmployeeGetReportsToAsync(int id) => await _queryGetReportsTo(this, id).ToListAsync();

        public async Task<List<Genre>> GetAllGenresAsync() => await _queryGetAllGenres(this).ToListAsync();

        public async Task<List<Genre>> GetGenreAsync(int id) => await _queryGetGenre(this, id).ToListAsync();

        public async Task<List<InvoiceLine>> GetAllInvoiceLinesAsync() => await _queryGetAllInvoiceLines(this).ToListAsync();

        public async Task<List<InvoiceLine>> GetInvoiceLineAsync(int id) => await _queryGetInvoiceLine(this, id).ToListAsync();

        public async Task<List<InvoiceLine>> GetInvoiceLinesByInvoiceIdAsync(int id) => await _queryGetInvoiceLinesByInvoiceId(this, id).ToListAsync();

        public async Task<List<InvoiceLine>> GetInvoiceLinesByTrackIdAsync(int id) => await _queryGetInvoiceLinesByTrackId(this, id).ToListAsync();

        public async Task<List<Invoice>> GetAllInvoicesAsync() => await _queryGetAllInvoices(this).ToListAsync();

        public async Task<List<Invoice>> GetInvoiceAsync(int id) => await _queryGetInvoice(this, id).ToListAsync();

        public async Task<List<Invoice>> GetInvoicesByCustomerIdAsync(int id) => await _queryGetInvoicesByCustomerId(this, id).ToListAsync();

        public async Task<List<MediaType>> GetAllMediaTypesAsync() => await _queryGetAllMediaTypes(this).ToListAsync();

        public async Task<List<MediaType>> GetMediaTypeAsync(int id) => await _queryGetMediaType(this, id).ToListAsync();

        public async Task<List<Playlist>> GetAllPlaylistsAsync() => await _queryGetAllPlaylists(this).ToListAsync();

        public async Task<List<Playlist>> GetPlaylistAsync(int id) => await _queryGetPlaylist(this, id).ToListAsync();

        public async Task<List<PlaylistTrack>> GetAllPlaylistTracksAsync() => await _queryGetAllPlaylistTracks(this).ToListAsync();

        public async Task<List<PlaylistTrack>> GetPlaylistTrackByPlaylistId(int id) => await _queryGetPlaylistTrackByPlaylistId(this, id).ToListAsync();

        public async Task<List<PlaylistTrack>> GetPlaylistTracksByTrackIdAsync(int id) => await _queryGetPlaylistTracksByTrackId(this, id).ToListAsync();

        public async Task<List<Track>> GetAllTracksAsync() => await _queryGetAllTracks(this).ToListAsync();

        public async Task<List<Track>> GetTrackAsync(int id) => await _queryGetTrack(this, id).ToListAsync();

        public async Task<List<Track>> GetTracksByAlbumIdAsync(int id) => await _queryGetTracksByAlbumId(this, id).ToListAsync();

        public async Task<List<Track>> GetTracksByGenreIdAsync(int id) => await _queryGetTracksByGenreId(this, id).ToListAsync();

        public async Task<List<Track>> GetTracksByMediaTypeIdAsync(int id) => await _queryGetTracksByMediaTypeId(this, id).ToListAsync();
    }
}