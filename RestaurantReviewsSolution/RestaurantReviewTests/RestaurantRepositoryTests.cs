using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using RestaurantReviewsModels;
using System.Data.Entity;
using BusinessLogic;

namespace Repository.Tests
{
    [TestClass()]
    public class RestaurantRepositoryTests
    {
        private readonly Mock<IRestaurantRepository> TestRepo;
        private readonly Mock<DbSet<Restaurant>> TestSet;

        public RestaurantRepositoryTests()
        {
            TestRepo = new Mock<IRestaurantRepository>();
            TestSet = new Mock<DbSet<Restaurant>>();

            TestRepo.Setup(m => m.GetAllRestaurants()).Returns(TestSet.Object);
        }

        [TestMethod()]
        public void AddRestaurantTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteRestaurantTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllRestaurantsTest()
        {
            var service = new RestaurantRepository(TestRepo.Object);
            var restById = service.GetAll();

            Assert.IsInstanceOfType(restById, typeof(IEnumerable<Restaurant>));
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ModifyRestaurantTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveRestaurantsTest()
        {
            Assert.Fail();
        }
    }
}