using Moq;
using NUnit.Framework;
using Rasot.Core.Domain.Customers;
using Rasot.Core.Infrastructures;
using Rasot.Data;
using Rasot.Service.Services.Authentications;
using Rasot.Service.Services.Authentications.Models;
using Rasot.Service.Services.Customers;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class CustomerTest
    {
        private Mock<IRepository<Customer>> _customerRepository;
        private Mock<IDbContext> _dbcontext;
        [SetUp]
        public void Setup()
        {
            _customerRepository = new Mock<IRepository<Customer>>();
            _dbcontext = new Mock<IDbContext>();


            var customer = new Customer()
            {
                Id = 1,
                Email = "cngz.gur@gmail.com",
                Password = "001453",
                PasswordSalt = "001453",
                PasswordFormatType = 1
            };

            _customerRepository.Setup(p => p.Table).Returns(new List<Customer>() { customer}.AsQueryable());
        }


        [Test]
        public void CustomerInsert()
        {

          
            var _customerService = new CustomerService(_customerRepository.Object);
            var customer = new Rasot.Core.Domain.Customers.Customer();
            customer.Email = "cngz.gur@gmail.com";
            customer.Password = "001453";
            customer.PasswordFormatType = 1;
            customer.PasswordSalt = "123456";
            _customerService.Insert(customer);
        }

        [Test]
        public void CustomerLogin()
        {
            var authService = new AuthenticationService(_customerRepository.Object);

           var result= authService.Login(new Rasot.Service.Services.Authentications.Models.LoginRequest() {
                 Email="cngz.gur@gmail.com",
                 Password="001453"
            });
            Assert.IsTrue(result.Success);
        }

        [Test]
        public void CustomerRegister()
        {
            var authService = new AuthenticationService(_customerRepository.Object);

            RegisterRequest customer = new RegisterRequest();
           
            customer.Email = "cengiz.gur@hotmail.com.tr";
            customer.Password = "001453";
            customer.UserName = "Cengiz Gür";

            var result=authService.Register(customer);

            Assert.IsTrue(result.Success);
        }


    }
}