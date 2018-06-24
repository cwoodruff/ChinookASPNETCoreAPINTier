using System.Collections.Generic;
using System.Linq;
using Chinook.Domain.Entities;
using Chinook.Domain.ViewModels;

namespace Chinook.Domain.Converters
{
    public static class EmployeeCoverter
    {
        public static EmployeeViewModel Convert(Employee employee)
        {
            var employeeViewModel = new EmployeeViewModel();
            employeeViewModel.EmployeeId = employee.EmployeeId;
            employeeViewModel.LastName = employee.LastName;
            employeeViewModel.FirstName = employee.FirstName;
            employeeViewModel.Title = employee.Title;
            employeeViewModel.ReportsTo = employee.ReportsTo;
            employeeViewModel.BirthDate = employee.BirthDate;
            employeeViewModel.HireDate = employee.HireDate;
            employeeViewModel.Address = employee.Address;
            employeeViewModel.City = employee.City;
            employeeViewModel.State = employee.State;
            employeeViewModel.Country = employee.Country;
            employeeViewModel.PostalCode = employee.PostalCode;
            employeeViewModel.Phone = employee.Phone;
            employeeViewModel.Fax = employee.Fax;
            employeeViewModel.Email = employee.Email;

            return employeeViewModel;
        }
        
        public static List<EmployeeViewModel> ConvertList(IEnumerable<Employee> employees)
        {
            return employees.Select(e =>
                {
                    var model = new EmployeeViewModel();
                    model.EmployeeId = e.EmployeeId;
                    model.LastName = e.LastName;
                    model.FirstName = e.FirstName;
                    model.Title = e.Title;
                    model.ReportsTo = e.ReportsTo;
                    model.BirthDate = e.BirthDate;
                    model.HireDate = e.HireDate;
                    model.Address = e.Address;
                    model.City = e.City;
                    model.State = e.State;
                    model.Country = e.Country;
                    model.PostalCode = e.PostalCode;
                    model.Phone = e.Phone;
                    model.Fax = e.Fax;
                    model.Email = e.Email;
                    return model;
                })
                .ToList();
        }
    }
}