using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Chinook.Domain.Repositories;
using Chinook.Domain.Entities;

namespace Chinook.DataEFCoreCmpldQry.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly ChinookContext _context;
        
        private static readonly Func<ChinookContext, CancellationToken, Task<List<Album>>> QueryGetAllAlbums =
            EF.CompileAsyncQuery((ChinookContext db, CancellationToken ct) =>
                db.Album.ToList());
        
        private static readonly Func<ChinookContext, CancellationToken, int, Task<Album>> QueryGetAlbum =
            EF.CompileAsyncQuery((ChinookContext db, CancellationToken ct, int id) =>
                db.Album.Find(id));

        private static readonly Func<ChinookContext, CancellationToken, int, Task<List<Album>>> QueryGetAlbumsByArtistId =
            EF.CompileAsyncQuery((ChinookContext db, CancellationToken ct, int id) =>
                db.Album.Where(a => a.ArtistId == id).ToList());

        public AlbumRepository(ChinookContext context)
        {
            _context = context;
        }

        private async Task<bool> AlbumExists(int id, CancellationToken ct = default(CancellationToken))
        {
            return await GetByIdAsync(id, ct) != null;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<Album>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            return await QueryGetAllAlbums(_context, ct);
        }

        public async Task<Album> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await QueryGetAlbum(_context, ct, id);
        }

        public async Task<Album> AddAsync(Album newAlbum, CancellationToken ct = default(CancellationToken))
        {
            _context.Album.Add(newAlbum);
            await _context.SaveChangesAsync(ct);
            return newAlbum;
        }

        public async Task<bool> UpdateAsync(Album album, CancellationToken ct = default(CancellationToken))
        {
            if (!await AlbumExists(album.AlbumId, ct))
                return false;
            _context.Album.Update(album);

            _context.Update(album);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            if (!await AlbumExists(id, ct))
                return false;
            var toRemove = _context.Album.Find(id);
            _context.Album.Remove(toRemove);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<List<Album>> GetByArtistIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await QueryGetAlbumsByArtistId(_context, ct, id);
        }
    }
}