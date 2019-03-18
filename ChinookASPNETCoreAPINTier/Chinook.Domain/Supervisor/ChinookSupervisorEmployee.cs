using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.ViewModels;
using Chinook.Domain.Converters;
using Chinook.Domain.Entities;

namespace Chinook.Domain.Supervisor
{
    public partial class ChinookSupervisor
    {
        public async Task<List<EmployeeViewModel>> GetAllEmployeeAsync(
            CancellationToken ct = default(CancellationToken))
        {
            var employees = EmployeeCoverter.ConvertList(await _employeeRepository.GetAllAsync(ct));
            return employees;
        }

        public async Task<EmployeeViewModel> GetEmployeeByIdAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            var employeeViewModel = EmployeeCoverter.Convert(await _employeeRepository.GetByIdAsync(id, ct));
            employeeViewModel.Customers = await GetCustomerBySupportRepIdAsync(employeeViewModel.EmployeeId, ct);
            employeeViewModel.DirectReports = await GetEmployeeDirectReportsAsync(employeeViewModel.EmployeeId, ct);
            employeeViewModel.Manager = employeeViewModel.ReportsTo.HasValue
                ? await GetEmployeeReportsToAsync(employeeViewModel.ReportsTo.GetValueOrDefault(), ct)
                : null;
            employeeViewModel.ReportsToName = employeeViewModel.ReportsTo.HasValue
                ? $"{employeeViewModel.Manager.LastName}, {employeeViewModel.Manager.FirstName}"
                : string.Empty;
            return employeeViewModel;
        }

        public async Task<EmployeeViewModel> GetEmployeeReportsToAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            var employee = await _employeeRepository.GetReportsToAsync(id, ct);
            return EmployeeCoverter.Convert(employee);
        }

        public async Task<EmployeeViewModel> AddEmployeeAsync(EmployeeViewModel newEmployeeViewModel,
            CancellationToken ct = default(CancellationToken))
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

        public async Task<bool> UpdateEmployeeAsync(EmployeeViewModel employeeViewModel,
            CancellationToken ct = default(CancellationToken))
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

        public async Task<List<EmployeeViewModel>> GetEmployeeDirectReportsAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            var employees = await _employeeRepository.GetDirectReportsAsync(id, ct);
            return EmployeeCoverter.ConvertList(employees).ToList();
        }

        public async Task<List<EmployeeViewModel>> GetDirectReportsAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            var employees = await _employeeRepository.GetDirectReportsAsync(id, ct);
            return EmployeeCoverter.ConvertList(employees).ToList();
        }
    }
}