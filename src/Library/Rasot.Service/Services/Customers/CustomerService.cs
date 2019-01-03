using Rasot.Core.Domain.Customers;
using Rasot.Core.Infrastructures;

namespace Rasot.Service.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        #region Fields
            private readonly IRepository<Customer> _customerRepository;
        #endregion
        #region Ctor
            public CustomerService(IRepository<Customer> customerRepository)
            {
                _customerRepository = customerRepository;
            }
        #endregion
        #region Implementations
            public virtual void Insert(Customer item)
            {
                _customerRepository.Insert(item);
            }
            public virtual Customer Find(int Id)
            {
                return _customerRepository.Find(Id);
            }

        #endregion
    }
}
