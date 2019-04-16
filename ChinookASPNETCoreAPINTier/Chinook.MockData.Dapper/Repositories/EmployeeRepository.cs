using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Entities;
using Chinook.Domain.Repositories;

namespace Chinook.MockData.Dapper.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public void Dispose()
        {
        }

        public async Task<List<Employee>> GetAllAsync(CancellationToken ct = default)
        {
            IList<Employee> list = new List<Employee>();

            var employee = new Employee
            {
                EmployeeId = 1
            };
            list.Add(employee);

            return list.ToList();
        }

        public async Task<Employee> GetByIdAsync(int id, CancellationToken ct = default)
        {
            string reportsToName;
            var employee = new Employee
            {
                EmployeeId = id
            };
            return employee;
        }

        public async Task<Employee> AddAsync(Employee newEmployee, CancellationToken ct = default) => newEmployee;

        public async Task<bool> UpdateAsync(Employee employee, CancellationToken ct = default) => true;

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default) => true;

        public async Task<Employee> GetReportsToAsync(int id, CancellationToken ct = default)
        {
            var employee = new Employee
            {
                EmployeeId = id
            };
            return employee;
        }

        public async Task<List<Employee>> GetDirectReportsAsync(int id,
            CancellationToken ct = default)
        {
            IList<Employee> list = new List<Employee>();
            var employee = new Employee
            {
                EmployeeId = id
            };
            list.Add(employee);
            return list.ToList();
        }
    }
}