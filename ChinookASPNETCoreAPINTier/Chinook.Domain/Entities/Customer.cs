using Chinook.Domain.Converters;
using Chinook.Domain.ApiModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Chinook.Domain.Entities
{
    public class Customer : IConvertModel<Customer, CustomerApiModel>
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
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

        [NotMapped]
        [JsonIgnore]
        public ICollection<Invoice> Invoices { get; set; } = new HashSet<Invoice>();
        [NotMapped]
        [JsonIgnore]
        public Employee SupportRep { get; set; }

        public CustomerApiModel Convert() => new CustomerApiModel
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