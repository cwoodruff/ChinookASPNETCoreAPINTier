using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Chinook.Domain.DbInfo;
using Chinook.Domain.Repositories;
using Chinook.Domain.Entities;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Chinook.DataDapper.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DbInfo _dbInfo;

        public GenreRepository(DbInfo dbInfo)
        {
            _dbInfo = dbInfo;
        }

        private IDbConnection Connection => new SqlConnection(_dbInfo.ConnectionStrings);

        public void Dispose()
        {
            
        }
        
        private async Task<bool> GenreExists(int id, CancellationToken ct = default)
        {
            return await GetByIdAsync(id, ct) != null;
        }

        public async Task<List<Genre>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                var genres = await Connection.QueryAsync<Genre>("Select * From Genre");
                return genres.ToList();
            }
        }

        public async Task<Genre> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            using (var cn = Connection)
            {
                cn.Open();
                return await cn.QueryFirstOrDefaultAsync<Genre>("Select * From Genre WHERE Id = @Id", new {id});
            }
        }

        public async Task<Genre> AddAsync(Genre newGenre, CancellationToken ct = default(CancellationToken))
        {
            using (var cn = Connection)
            {
                cn.Open();

                newGenre.GenreId = await cn.InsertAsync(new Genre {Name = newGenre.Name});
            }

            return newGenre;
        }

        public async Task<bool> UpdateAsync(Genre genre, CancellationToken ct = default(CancellationToken))
        {
            if (!await GenreExists(genre.GenreId, ct))
                return false;

            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    return await cn.UpdateAsync(genre);
                }
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    return await cn.DeleteAsync(new Genre {GenreId = id});
                }  
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}