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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DbInfo _dbInfo;

        public EmployeeRepository(DbInfo dbInfo)
        {
            _dbInfo = dbInfo;
        }

        private IDbConnection Connection => new SqlConnection(_dbInfo.ConnectionStrings);

        public void Dispose()
        {
            
        }

        private async Task<bool> EmployeeExists(int id, CancellationToken ct = default) => await GetByIdAsync(id, ct) != null;

        public async Task<List<Employee>> GetAllAsync(CancellationToken ct = default)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                var employees = await Connection.QueryAsync<Employee>("Select * From Employee");
                return employees.ToList();
            }
        }

        public async Task<Employee> GetByIdAsync(int id, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();
                return await cn.QueryFirstOrDefaultAsync<Employee>("Select * From Employee WHERE Id = @Id", new {id});
            }
        }

        public async Task<Employee> GetReportsToAsync(int id, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();
                return await cn.QueryFirstOrDefaultAsync<Employee>("Select * From Employee WHERE Id = @Id", new {id});
            }
        }

        public async Task<Employee> AddAsync(Employee newEmployee, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();

                newEmployee.EmployeeId = await cn.InsertAsync(
                    new Employee
                    {
                        LastName = newEmployee.LastName,
                        FirstName = newEmployee.FirstName,
                        Title = newEmployee.Title,
                        ReportsTo = newEmployee.ReportsTo,
                        BirthDate = newEmployee.BirthDate,
                        HireDate = newEmployee.HireDate,
                        Address = newEmployee.Address,
                        City = newEmployee.City,
                        State = newEmployee.State,
                        Country = newEmployee.Country,
                        PostalCode = newEmployee.PostalCode,
                        Phone = newEmployee.Phone,
                        Fax = newEmployee.Fax,
                        Email = newEmployee.Email
                    });
            }

            return newEmployee;
        }

        public async Task<bool> UpdateAsync(Employee employee, CancellationToken ct = default)
        {
            if (!await EmployeeExists(employee.EmployeeId, ct))
                return false;

            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    return await cn.UpdateAsync(employee);
                }
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            try
            {
                using (var cn = Connection)
                {
                    cn.Open();
                    return await cn.DeleteAsync(new Employee {EmployeeId = id});
                }  
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<List<Employee>> GetDirectReportsAsync(int id, CancellationToken ct = default)
        {
            using (var cn = Connection)
            {
                cn.Open();
                var employees = await cn.QueryAsync<Employee>("Select * From Employee WHERE ArtistId = @Id", new { id });
                return employees.ToList();
            }
        }
    }
}