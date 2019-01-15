using Rasot.Core.Domain.Customers;
using Rasot.Core.Infrastructures;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Rasot.Core.Domain.Contents;
using System;
using System.Linq.Expressions;

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
            public virtual Customer Find(int Id, params Expression<Func<Customer, object>>[] includes)
            {

            return _customerRepository.Table.Include(p => p.Posts)
                                            .ThenInclude(post => post.PostCategories)
                                            .FirstOrDefault(p => p.Id == Id);
            }

        #endregion
    }
}
