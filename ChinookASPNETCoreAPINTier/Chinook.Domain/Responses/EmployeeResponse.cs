using System;
using System.Collections.Generic;

namespace Chinook.Domain.Responses
{
    public class EmployeeResponse
    {
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public int? ReportsTo { get; set; }
        public string ReportsToName { get; set; }
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

        public List<CustomerResponse> Customers { get; set; }
        public EmployeeResponse Manager { get; set; }
        public ICollection<EmployeeResponse> DirectReports { get; set; }
    }
}