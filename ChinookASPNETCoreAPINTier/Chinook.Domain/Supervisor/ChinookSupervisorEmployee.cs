using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.Extensions;
using Chinook.Domain.Responses;
using Chinook.Domain.Converters;
using Chinook.Domain.Entities;

namespace Chinook.Domain.Supervisor
{
    public partial class ChinookSupervisor
    {
        public async Task<IEnumerable<EmployeeResponse>> GetAllEmployeeAsync(
            CancellationToken ct = default)
        {
            var employees = await _employeeRepository.GetAllAsync(ct);
            return employees.ConvertAll();
        }

        public async Task<EmployeeResponse> GetEmployeeByIdAsync(int id,
            CancellationToken ct = default)
        {
            var employeeViewModel = (await _employeeRepository.GetByIdAsync(id, ct)).Convert;
            employeeViewModel.Customers = (await GetCustomerBySupportRepIdAsync(employeeViewModel.EmployeeId, ct)).ToList();
            employeeViewModel.DirectReports = (await GetEmployeeDirectReportsAsync(employeeViewModel.EmployeeId, ct)).ToList();
            employeeViewModel.Manager = employeeViewModel.ReportsTo.HasValue
                ? await GetEmployeeReportsToAsync(employeeViewModel.ReportsTo.GetValueOrDefault(), ct)
                : null;
            employeeViewModel.ReportsToName = employeeViewModel.ReportsTo.HasValue
                ? $"{employeeViewModel.Manager.LastName}, {employeeViewModel.Manager.FirstName}"
                : string.Empty;
            return employeeViewModel;
        }

        public async Task<EmployeeResponse> GetEmployeeReportsToAsync(int id,
            CancellationToken ct = default)
        {
            var employee = await _employeeRepository.GetReportsToAsync(id, ct);
            return employee.Convert;
        }

        public async Task<EmployeeResponse> AddEmployeeAsync(EmployeeResponse newEmployeeViewModel,
            CancellationToken ct = default)
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

        public async Task<bool> UpdateEmployeeAsync(EmployeeResponse employeeViewModel,
            CancellationToken ct = default)
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

        public async Task<bool> DeleteEmployeeAsync(int id, CancellationToken ct = default) 
            => await _employeeRepository.DeleteAsync(id, ct);

        public async Task<IEnumerable<EmployeeResponse>> GetEmployeeDirectReportsAsync(int id,
            CancellationToken ct = default)
        {
            var employees = await _employeeRepository.GetDirectReportsAsync(id, ct);
            return employees.ConvertAll();
        }

        public async Task<IEnumerable<EmployeeResponse>> GetDirectReportsAsync(int id,
            CancellationToken ct = default)
        {
            var employees = await _employeeRepository.GetDirectReportsAsync(id, ct);
            return employees.ConvertAll();
        }
    }
}