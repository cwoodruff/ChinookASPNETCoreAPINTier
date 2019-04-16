using System.Collections.Generic;

namespace Chinook.Domain.Responses
{
    public class CustomerResponse
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

        public IList<InvoiceResponse> Invoices { get; set; }
        public EmployeeResponse SupportRep { get; set; }
    }
}