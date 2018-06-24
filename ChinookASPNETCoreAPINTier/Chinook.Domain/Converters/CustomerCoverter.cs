using System.Collections.Generic;
using System.Linq;
using Chinook.Domain.Entities;
using Chinook.Domain.ViewModels;

namespace Chinook.Domain.Converters
{
    public static class CustomerCoverter
    {
        public static CustomerViewModel Convert(Customer customer)
        {
            var customerViewModel = new CustomerViewModel();
            customerViewModel.CustomerId = customer.CustomerId;
            customerViewModel.FirstName = customer.FirstName;
            customerViewModel.LastName = customer.LastName;
            customerViewModel.Company = customer.Company;
            customerViewModel.Address = customer.Address;
            customerViewModel.City = customer.City;
            customerViewModel.State = customer.State;
            customerViewModel.Country = customer.Country;
            customerViewModel.PostalCode = customer.PostalCode;
            customerViewModel.Phone = customer.Phone;
            customerViewModel.Fax = customer.Fax;
            customerViewModel.Email = customer.Email;
            customerViewModel.SupportRepId = customer.SupportRepId;

            return customerViewModel;
        }
        
        public static IEnumerable<CustomerViewModel> ConvertList(IEnumerable<Customer> customers)
        {
            return customers.Select(c =>
                {
                    var model = new CustomerViewModel();
                    model.CustomerId = c.CustomerId;
                    model.FirstName = c.FirstName;
                    model.LastName = c.LastName;
                    model.Company = c.Company;
                    model.Address = c.Address;
                    model.City = c.City;
                    model.State = c.State;
                    model.Country = c.Country;
                    model.PostalCode = c.PostalCode;
                    model.Phone = c.Phone;
                    model.Fax = c.Fax;
                    model.Email = c.Email;
                    model.SupportRepId = c.SupportRepId;
                    return model;
                })
                .ToList();
        }
    }
}