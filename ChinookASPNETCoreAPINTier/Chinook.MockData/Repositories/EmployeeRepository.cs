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

        public Task<List<Employee>> GetAllAsync(CancellationToken ct = default)
            => new Employee
            {
                EmployeeId = 1
            }.AsListTask();

        public Task<Employee> GetByIdAsync(int id, CancellationToken ct = default)
            => new Employee
            {
                EmployeeId = id
            }.AsTask();

        public Task<Employee> AddAsync(Employee newEmployee, CancellationToken ct = default) => newEmployee.AsTask();

        public Task<bool> UpdateAsync(Employee employee, CancellationToken ct = default) => true.AsTask();

        public Task<bool> DeleteAsync(int id, CancellationToken ct = default) => true.AsTask();

        public Task<Employee> GetReportsToAsync(int id, CancellationToken ct = default)
            => new Employee
            {
                EmployeeId = id
            }.AsTask();

        public Task<List<Employee>> GetDirectReportsAsync(int id,
            CancellationToken ct = default)
            => new Employee
            {
                EmployeeId = id
            }.AsListTask();
    }
}