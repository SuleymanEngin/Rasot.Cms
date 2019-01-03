using Moq;
using NUnit.Framework;
using Rasot.Core.Domain.Customers;
using Rasot.Core.Infrastructures;
using Rasot.Service.Services.Customers;
using Rasot.Web.Factories;
using System.Collections.Generic;
using System.Linq;

namespace Rasot.Core.Tests
{
    [TestFixture]
    public class CustomerModelFactoryTest
    {

        private Mock<ICustomerService> _customerService;
        private Mock<IRepository<Customer>> _customerRepository;

        [SetUp]
        public void Setup()
        {

            _customerService = new Mock<ICustomerService>();
            _customerRepository = new Mock<IRepository<Customer>>();

            var customer = new Customer();
            customer.Email = "cngz.gur@gmail.com";
            customer.Id = 1;
            customer.PasswordFormatType = 1;
            customer.Password = "001453";
            customer.PasswordSalt = "123456";

            _customerRepository.Setup(p => p.Table).Returns(new List<Customer>() { customer }.AsQueryable());

        }

        [Test]
        public void PrepareShortModel()
        {
            var customerModelFactory = new CustomerModelFactory(_customerService.Object);
            var model = customerModelFactory.PrepareCustomerShortModel(1);

        
        }
    }
}
