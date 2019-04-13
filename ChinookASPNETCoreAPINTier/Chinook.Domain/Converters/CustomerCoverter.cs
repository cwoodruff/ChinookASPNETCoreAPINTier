using System.Collections.Generic;
using System.Linq;
using Chinook.Domain.Entities;
using Chinook.Domain.Responses;

namespace Chinook.Domain.Converters
{
    public static class CustomerCoverter
    {
        public static CustomerResponse Convert(Customer customer)
            => new CustomerResponse
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Company = customer.Company,
                Address = customer.Address,
                City = customer.City,
                State = customer.State,
                Country = customer.Country,
                PostalCode = customer.PostalCode,
                Phone = customer.Phone,
                Fax = customer.Fax,
                Email = customer.Email,
                SupportRepId = customer.SupportRepId
            };

        public static IEnumerable<CustomerResponse> ConvertList(IEnumerable<Customer> customers) 
            => customers.Select(Convert).ToList();
    }
}