using Rasot.Service.Services.Customers;
using Rasot.Web.Models.Customers;
using System;

namespace Rasot.Web.Factories
{
    public class CustomerModelFactory : ICustomerModelFactory
    {
        private readonly ICustomerService _customerService;
        public CustomerModelFactory(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public virtual CustomerShortModel PrepareCustomerShortModel(int Id)
        {
            var customer = _customerService.Find(Id, p => p.Posts);
            if(customer ==null)
            {
                throw new ArgumentNullException($"Customer",$"Customer cannot be null");
            }

            var customerShortModel = new CustomerShortModel();
            customerShortModel.Email = customer.Email;
            customerShortModel.Name = customer.Name;

            return customerShortModel;
        }
    }
}
