using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Rasot.Core.Domain.Customers;
using Rasot.Core.Infrastructures;
using Rasot.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rasot.Core.Tests
{
    [TestFixture]
    public class DbContextTest
    {
        private IDbContext _dbContext;
        private IRepository<Customer> _repository;
        [SetUp]
        public void Setup()
        {
            var optionBuilder = new DbContextOptionsBuilder<RasotDbContext>();
            optionBuilder.UseMySQL("server=localhost;port=3306; database=rasotdb; uid=root; password=001453");

            _dbContext = new RasotDbContext(optionBuilder.Options);
            _repository = new Repository<Customer>(_dbContext);

        }


       [Test]
       public void Set_Should()
        {
           var dbSet= _dbContext.Set<Customer>();

        }

        [Test]
        public void Repository_Should()
        {
            var table = _repository.Table.ToList();

        }

        [Test]
        public void Repository_Delete()
        {
          

        }
    }
}
