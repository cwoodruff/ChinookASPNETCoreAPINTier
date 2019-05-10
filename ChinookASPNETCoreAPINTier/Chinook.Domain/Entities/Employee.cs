using Chinook.Domain.Converters;
using Chinook.Domain.ApiModels;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Chinook.Domain.Entities
{
    public class Employee : IConvertModel<Employee, EmployeeApiModel>
    {
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public int? ReportsTo { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }

        public ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();
        public Employee Manager { get; set; }
        public ICollection<Employee> DirectReports { get; set; } = new HashSet<Employee>();

        [JsonIgnore]
        public EmployeeApiModel Convert => new EmployeeApiModel
        {
            EmployeeId = EmployeeId,
            LastName = LastName,
            FirstName = FirstName,
            Title = Title,
            ReportsTo = ReportsTo,
            BirthDate = BirthDate,
            HireDate = HireDate,
            Address = Address,
            City = City,
            State = State,
            Country = Country,
            PostalCode = PostalCode,
            Phone = Phone,
            Fax = Fax,
            Email = Email
        };
    }
}