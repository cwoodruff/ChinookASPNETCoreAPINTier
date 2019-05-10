using System.Collections.Generic;
using Chinook.Domain.Entities;
using Newtonsoft.Json;

namespace Chinook.Domain.ApiModels
{
    public class CustomerApiModel
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int? SupportRepId { get; set; }
        public string SupportRepName { get; set; }

        public IList<InvoiceApiModel> Invoices { get; set; }
        public EmployeeApiModel SupportRep { get; set; }
        
        [JsonIgnore]
        public Customer Convert => new Customer
        {
            CustomerId = CustomerId,
            FirstName = FirstName,
            LastName = LastName,
            Company = Company,
            Address = Address,
            City = City,
            State = State,
            Country = Country,
            PostalCode = PostalCode,
            Phone = Phone,
            Fax = Fax,
            Email = Email,
            SupportRepId = SupportRepId
        };
    }
}