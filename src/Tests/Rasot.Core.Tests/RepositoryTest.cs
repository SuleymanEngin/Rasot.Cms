using Moq;
using NUnit.Framework;
using Rasot.Core.Domain.Contents;
using Rasot.Core.Infrastructures;
using Rasot.Data;
using Rasot.Service.Services.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rasot.Core.Tests
{
    [TestFixture]
    public   class RepositoryTest
    {
        public List<Post> mockData;
        public Mock<IRepository<Post>> _genericRepository;
        public IPostService _postService;
        public Mock<IDbContext> _dbContext;

        [SetUp]
        public void Setup()
        {
            _dbContext = new Mock<IDbContext>();

            _genericRepository = new Mock<IRepository<Post>>();
            _postService = new PostService(_genericRepository.Object);

            mockData = new List<Post>();

            mockData.Add(new Post() {
                 Id=1,
                 Title="Merhaba Dünya",
                 Content="Dünyanın geleceği yeniden yazılıyor"
            });

            mockData.Add(new Post()
            {
                Id = 2,
                Title = "Merhaba Dünya",
                Content = "Dünyanın geleceği yeniden yazılıyor"
            });
            mockData.Add(new Post()
            {
                Id = 3,
                Title = "Merhaba Dünya",
                Content = "Dünyanın geleceği yeniden yazılıyor"
            });
            mockData.Add(new Post()
            {
                Id = 4,
                Title = "Merhaba Dünya",
                Content = "Dünyanın geleceği yeniden yazılıyor"
            });

            _genericRepository.Setup(p => p.Table).Returns(mockData.AsQueryable());

        }

        [Test]
        public void Insert()
        {

          
            var newPostItem = new Post()
            {
                 Id = 7,
                 Title="Merhaba Dünya",
                 Content="Merhaba Dünyanın geleceği robotiumlar"
            };
           
           _postService.Insert(newPostItem);

            var items = _postService.FindAll();
            var item=items.FirstOrDefault(p => p.Id == 7);
        }

        [Test]
        public void Update()
        {

            var item = _postService.FindAll().FirstOrDefault(p => p.Id == 3);
            item.Title = "Cengiz Gür";
            _postService.Update(item);
        }

        [Test]
        public void Find()
        {
            var item = _postService.FindAll().FirstOrDefault(p => p.Id == 1);

            Assert.IsNotNull(item);
        }

        [Test]
        public void FindAll()
        {
           var items= _postService.FindAll();
            Assert.IsNotNull(items);
        }
    }
}
