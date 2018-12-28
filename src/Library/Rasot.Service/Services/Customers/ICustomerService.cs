using Rasot.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rasot.Service.Services.Customers
{
    public interface ICustomerService
    {
        void Insert(Customer item);
    }
}
