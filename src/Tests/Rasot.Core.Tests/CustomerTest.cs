using NUnit.Framework;
using Rasot.Service.Services.Customers;

namespace Tests
{
    [TestFixture]
    public class CustomerTest
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void CustomerInsert()
        {
            var customerService = new CustomerService();
            var customer = new Rasot.Core.Domain.Customers.Customer();
            customerService.Insert(customer);
            Assert.Greater(customer.Id, 0);

        }



       
    }
}