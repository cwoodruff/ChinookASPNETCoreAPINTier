using System.Collections.Generic;
using System.Linq;
using Chinook.Domain.Entities;
using Chinook.Domain.Responses;

namespace Chinook.Domain.Converters
{
    public static class EmployeeCoverter
    {
        public static EmployeeResponse Convert(Employee employee)
            => new EmployeeResponse
            {
                EmployeeId = employee.EmployeeId,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Title = employee.Title,
                ReportsTo = employee.ReportsTo,
                BirthDate = employee.BirthDate,
                HireDate = employee.HireDate,
                Address = employee.Address,
                City = employee.City,
                State = employee.State,
                Country = employee.Country,
                PostalCode = employee.PostalCode,
                Phone = employee.Phone,
                Fax = employee.Fax,
                Email = employee.Email
            };

        public static List<EmployeeResponse> ConvertList(IEnumerable<Employee> employees) 
            => employees.Select(Convert).ToList();
    }
}