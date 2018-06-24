using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Chinook.Domain.Repositories;
using Chinook.Domain.Entities;

namespace Chinook.MockData.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public void Dispose()
        {
            
        }

        public async Task<List<Employee>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            IList<Employee> list = new List<Employee>();
               
                var employee = new Employee
                {
                    EmployeeId = 1
                };
                list.Add(employee);

            return list.ToList();
        }

        public async Task<Employee> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            string reportsToName;
            var employee = new Employee
            {
                EmployeeId = id
            };
            return employee;
        }

        public async Task<Employee> AddAsync(Employee newEmployee, CancellationToken ct = default(CancellationToken))
        {
            return newEmployee;
        }

        public async Task<bool> UpdateAsync(Employee employee, CancellationToken ct = default(CancellationToken))
        {
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return true;
        }

        public async Task<Employee> GetReportsToAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var employee = new Employee
            {
                EmployeeId = id
            };
            return employee;
        }
        
        public async Task<List<Employee>> GetDirectReportsAsync(int id, CancellationToken ct = default(CancellationToken))
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
