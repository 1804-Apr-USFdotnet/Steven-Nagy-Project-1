using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Repository;
using RestaurantReviewsModels;

namespace BusinessLogic.Tests
{
    [TestClass()]
    public class RevServicesTests
    {
        private readonly Mock<IRestaurantRepository> MockRestRepo;
        private readonly Mock<IReviewRepository> MockRevRepo;

        public RevServicesTests()
        {
            MockRestRepo = new Mock<IRestaurantRepository>();
            MockRestRepo.Setup(x => x.AddRestaurant(It.IsAny<Restaurant>()));
            MockRevRepo = new Mock<IReviewRepository>();
            MockRevRepo.Setup(x => x.AddReview(It.IsAny<Restaurant>(),It.IsAny<Review>()));
            
        }

        [TestMethod()]
        public void AddRevTest()
        {
            var restService = new RestServices(MockRestRepo.Object);
            Restaurant testaurant = new Restaurant(); testaurant.ID = 0; testaurant.restName = "fakeRestName"; testaurant.city = "fakeCity"; testaurant.latitude = "fake"; testaurant.longitude = "fake"; testaurant.locality = "land o fakes"; testaurant.ID = 0; testaurant.restAddress = "fakeAddress"; testaurant.cuisines = "fakeCuisine"; testaurant.zipcode = "12345";
            var revService = new RevServices(MockRevRepo.Object);
            Review testReview = new Review(); testReview.ID = 0; testReview.RestID = 0; testReview.rating = 3; testReview.reviewBody = "It's ok"; testReview.reviewer = "testReviewer";
            restService.AddRest(testaurant);
            revService.AddRev(testaurant,testReview);
            MockRevRepo.Verify(m => m.AddReview(It.IsAny<Restaurant>(), It.IsAny<Review>()), Times.Once);
        }

        [TestMethod()]
        public void DeleteRevTest()
        {
            var restService = new RestServices(MockRestRepo.Object);
            Restaurant testaurant = new Restaurant(); testaurant.ID = 0; testaurant.restName = "fakeRestName"; testaurant.city = "fakeCity"; testaurant.latitude = "fake"; testaurant.longitude = "fake"; testaurant.locality = "land o fakes"; testaurant.ID = 0; testaurant.restAddress = "fakeAddress"; testaurant.cuisines = "fakeCuisine"; testaurant.zipcode = "12345";
            var revService = new RevServices(MockRevRepo.Object);
            Review testReview = new Review(); testReview.ID = 0; testReview.RestID = 0; testReview.rating = 3; testReview.reviewBody = "It's ok"; testReview.reviewer = "testReviewer";
            restService.AddRest(testaurant);
            revService.AddRev(testaurant, testReview);
            revService.DeleteRev(testaurant, testReview);
            MockRevRepo.Verify(m => m.DeleteReview(It.IsAny<Restaurant>(), It.IsAny<Review>()), Times.Once);
        }

        [TestMethod()]
        public void GetAllRestReviewsTest()
        {
            var restService = new RestServices(MockRestRepo.Object);
            Restaurant testaurant = new Restaurant(); testaurant.ID = 0; testaurant.restName = "fakeRestName"; testaurant.city = "fakeCity"; testaurant.latitude = "fake"; testaurant.longitude = "fake"; testaurant.locality = "land o fakes"; testaurant.ID = 0; testaurant.restAddress = "fakeAddress"; testaurant.cuisines = "fakeCuisine"; testaurant.zipcode = "12345";
            var revService = new RevServices(MockRevRepo.Object);
            Review testReview = new Review(); testReview.ID = 0; testReview.RestID = 0; testReview.rating = 3; testReview.reviewBody = "It's ok"; testReview.reviewer = "testReviewer";
            restService.AddRest(testaurant);
            revService.AddRev(testaurant, testReview);
            revService.GetAllRestReviews(testaurant);
            MockRevRepo.Verify(m => m.GetAllReviewsByRestID(testaurant.ID), Times.Once);
        }

        [TestMethod()]
        public void GetReviewByRestAndIDTest()
        {
            var restService = new RestServices(MockRestRepo.Object);
            Restaurant testaurant = new Restaurant(); testaurant.ID = 0; testaurant.restName = "fakeRestName"; testaurant.city = "fakeCity"; testaurant.latitude = "fake"; testaurant.longitude = "fake"; testaurant.locality = "land o fakes"; testaurant.ID = 0; testaurant.restAddress = "fakeAddress"; testaurant.cuisines = "fakeCuisine"; testaurant.zipcode = "12345";
            var revService = new RevServices(MockRevRepo.Object);
            Review testReview = new Review(); testReview.ID = 0; testReview.RestID = 0; testReview.rating = 3; testReview.reviewBody = "It's ok"; testReview.reviewer = "testReviewer";
            restService.AddRest(testaurant);
            revService.AddRev(testaurant, testReview);
            revService.GetReviewByRestAndID(testaurant,testReview.ID);
            MockRevRepo.Verify(m => m.GetById(testaurant.ID,testReview.ID), Times.Once);
        }
    }
}