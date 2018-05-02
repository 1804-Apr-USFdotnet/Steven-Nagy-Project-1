using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using RestaurantReviewsModels;
using Repository;

namespace BusinessLogic.Tests
{
    [TestClass()]
    public class RestServicesTests
    {
        private readonly Mock<IRestaurantRepository> MockRepo;

        public RestServicesTests()
        {
            MockRepo = new Mock<IRestaurantRepository>();
            MockRepo.Setup(x => x.AddRestaurant(It.IsAny<Restaurant>()));
        }

        [TestMethod()]
        public void AddRestTest()
        {
            var service = new RestServices(MockRepo.Object);
            Restaurant testaurant = new Restaurant(); testaurant.ID = 0; testaurant.restName = "fakeRestName"; testaurant.city = "fakeCity"; testaurant.latitude = "fake"; testaurant.longitude = "fake"; testaurant.locality = "land o fakes"; testaurant.ID = 0; testaurant.restAddress = "fakeAddress"; testaurant.cuisines = "fakeCuisine"; testaurant.zipcode = "12345";
            service.AddRest(testaurant);
            MockRepo.Verify(m => m.AddRestaurant(It.IsAny<Restaurant>()), Times.Once);
        }

        [TestMethod()]
        public void AllRestsTest()
        {
            var service = new RestServices(MockRepo.Object);
            service.AllRests();
            MockRepo.Verify(m => m.GetAllRestaurants(), Times.Once);
        }

        [TestMethod()]
        public void DeleteRestTest()
        {
            var service = new RestServices(MockRepo.Object);
            Restaurant testaurant = new Restaurant(); testaurant.ID = 0; testaurant.restName = "fakeRestName"; testaurant.city = "fakeCity"; testaurant.latitude = "fake"; testaurant.longitude = "fake"; testaurant.locality = "land o fakes"; testaurant.ID = 0; testaurant.restAddress = "fakeAddress"; testaurant.cuisines = "fakeCuisine"; testaurant.zipcode = "12345";
            service.AddRest(testaurant);
            service.DeleteRest(testaurant);
            MockRepo.Verify(m => m.DeleteRestaurant(It.IsAny<Restaurant>()), Times.Once);
        }

        [TestMethod()]
        public void GetRestaurantByIDTest()
        {
            var service = new RestServices(MockRepo.Object);
            Restaurant testaurant = new Restaurant(); testaurant.ID = 0; testaurant.restName = "fakeRestName"; testaurant.city = "fakeCity"; testaurant.latitude = "fake"; testaurant.longitude = "fake"; testaurant.locality = "land o fakes"; testaurant.ID = 0; testaurant.restAddress = "fakeAddress"; testaurant.cuisines = "fakeCuisine"; testaurant.zipcode = "12345";
            service.AddRest(testaurant);
            service.GetRestaurantByID(testaurant.ID);
            MockRepo.Verify(m=>m.GetById(It.IsAny<int>()),Times.Once);
        }

        [TestMethod()]
        public void SearchAllTest()
        {
            var service = new RestServices(MockRepo.Object);
            List<Restaurant> checkList = service.SearchAll("fakeRest");
            foreach(Restaurant x in checkList)
            {
                Console.WriteLine(x.restName);
            }
            Assert.AreEqual(checkList[0],"fakeRest");
        }

        [TestMethod()]
        public void SortRestaurantsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void getAverageRatingTest()
        {
            var service = new RestServices(MockRepo.Object);
            Restaurant testaurant = new Restaurant(); testaurant.ID = 0; testaurant.restName = "fakeRestName"; testaurant.city = "fakeCity"; testaurant.latitude = "fake"; testaurant.longitude = "fake"; testaurant.locality = "land o fakes"; testaurant.ID = 0; testaurant.restAddress = "fakeAddress"; testaurant.cuisines = "fakeCuisine"; testaurant.zipcode = "12345";
            Review testReview1 = new Review(); testReview1.rating = 5; testReview1.RestID = testaurant.ID; testReview1.ID = 1; testReview1.reviewer = "john fakeman"; testReview1.reviewBody = "Real fake food!";
            Review testReview2 = new Review(); testReview2.rating = 1; testReview2.RestID = testaurant.ID; testReview2.ID = 2; testReview2.reviewer = "jenny fakewoman"; testReview2.reviewBody = "Real awful fake food!";
            testaurant.Reviews.Add(testReview1);
            testaurant.Reviews.Add(testReview2);
            double testD = service.getAverageRating(testaurant);
            Assert.AreEqual(3.0, testD);
        }

        [TestMethod()]
        public void TopThreeRestsTest()
        {
            var service = new RestServices(MockRepo.Object);
            service.TopThreeRests();
            MockRepo.Verify(m => m.GetAllRestaurants(), Times.Once);
        }

        [TestMethod()]
        public void UpdateRestTest()
        {
            Assert.Fail();
        }
    }
}