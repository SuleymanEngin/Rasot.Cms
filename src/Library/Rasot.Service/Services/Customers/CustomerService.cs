using Rasot.Core.Domain.Customers;

namespace Rasot.Service.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        public void Insert(Customer item)
        {
            item.Id = 1;
        }
    }
}
