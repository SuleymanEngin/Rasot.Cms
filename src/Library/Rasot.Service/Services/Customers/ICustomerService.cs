using Rasot.Core.Domain.Contents;
using Rasot.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Rasot.Service.Services.Customers
{
    public interface ICustomerService
    {
        void Insert(Customer item);
        Customer Find(int Id, params Expression<Func<Customer, object>>[] includes);
    }
}
