using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviewsModels;
using System.Configuration;

namespace BusinessLogic.Tests
{
    [TestClass()]
    public class SerializerTests
    {
        [TestMethod()]
        public void SerializedToFileTest()
        {
            Serializer test = new Serializer();
            List<Restaurant> testList = new List<Restaurant>();
            Restaurant testaurant = new Restaurant(); testaurant.ID = 0; testaurant.restName = "fakeRestName"; testaurant.city = "fakeCity"; testaurant.latitude = "fake"; testaurant.longitude = "fake"; testaurant.locality = "land o fakes"; testaurant.ID = 0; testaurant.restAddress = "fakeAddress"; testaurant.cuisines = "fakeCuisine"; testaurant.zipcode = "12345";
            Review testReview1 = new Review(); testReview1.rating = 5; testReview1.RestID = testaurant.ID; testReview1.ID = 1; testReview1.reviewer = "john fakeman"; testReview1.reviewBody = "Real fake food!";
            Review testReview2 = new Review(); testReview2.rating = 1; testReview2.RestID = testaurant.ID; testReview2.ID = 2; testReview2.reviewer = "jenny fakewoman"; testReview2.reviewBody = "Real awful fake food!";
            testaurant.Reviews.Add(testReview1);
            testaurant.Reviews.Add(testReview2);
            testList.Add(testaurant);
            string returnString = test.SerializeRestaurants(testList);
            test.SerializedToFile(returnString);
            string assertText = System.IO.File.ReadAllText(ConfigurationManager.AppSettings.GetValues("JSONpath")[0]);
            Assert.AreEqual(@"[{""ID"":0,""restName"":""fakeRestName"",""restAddress"":""fakeAddress"",""locality"":""land o fakes"",""city"":""fakeCity"",""latitude"":""fake"",""longitude"":""fake"",""zipcode"":""12345"",""cuisines"":""fakeCuisine"",""Reviews"":[{""ID"":1,""RestID"":0,""reviewer"":""john fakeman"",""rating"":5,""reviewBody"":""Real fake food!"",""Restaurant"":null},{""ID"":2,""RestID"":0,""reviewer"":""jenny fakewoman"",""rating"":1,""reviewBody"":""Real awful fake food!"",""Restaurant"":null}]}]", assertText);

        }

        [TestMethod()]
        public void SerializedFromFileTest()
        {
            Serializer test = new Serializer();
            List<Restaurant> testList = new List<Restaurant>();
            Restaurant testaurant = new Restaurant(); testaurant.ID = 0; testaurant.restName = "fakeRestName"; testaurant.city = "fakeCity"; testaurant.latitude = "fake"; testaurant.longitude = "fake"; testaurant.locality = "land o fakes"; testaurant.ID = 0; testaurant.restAddress = "fakeAddress"; testaurant.cuisines = "fakeCuisine"; testaurant.zipcode = "12345";
            Review testReview1 = new Review(); testReview1.rating = 5; testReview1.RestID = testaurant.ID; testReview1.ID = 1; testReview1.reviewer = "john fakeman"; testReview1.reviewBody = "Real fake food!";
            Review testReview2 = new Review(); testReview2.rating = 1; testReview2.RestID = testaurant.ID; testReview2.ID = 2; testReview2.reviewer = "jenny fakewoman"; testReview2.reviewBody = "Real awful fake food!";
            testaurant.Reviews.Add(testReview1);
            testaurant.Reviews.Add(testReview2);
            testList.Add(testaurant);
            string returnString = test.SerializeRestaurants(testList);
            test.SerializedToFile(returnString);
            List<Restaurant> testList2 = test.SerializedFromFile();
            Assert.AreEqual(testList[0].restName, testList2[0].restName);
            Assert.AreEqual(testList[0].Reviews.ElementAt(0).reviewer, testList[0].Reviews.ElementAt(0).reviewer);
        }

        [TestMethod()]
        public void SerializeRestaurantsTest()
        {
            Serializer test = new Serializer();
            List<Restaurant> testList = new List<Restaurant>();
            Restaurant testaurant = new Restaurant(); testaurant.ID = 0; testaurant.restName ="fakeRestName"; testaurant.city = "fakeCity"; testaurant.latitude = "fake"; testaurant.longitude = "fake"; testaurant.locality = "land o fakes"; testaurant.ID = 0; testaurant.restAddress = "fakeAddress"; testaurant.cuisines = "fakeCuisine"; testaurant.zipcode = "12345"; 
            Review testReview1 = new Review(); testReview1.rating = 5; testReview1.RestID = testaurant.ID; testReview1.ID = 1; testReview1.reviewer = "john fakeman"; testReview1.reviewBody = "Real fake food!";
            Review testReview2 = new Review(); testReview2.rating = 1; testReview2.RestID = testaurant.ID; testReview2.ID = 2; testReview2.reviewer = "jenny fakewoman"; testReview2.reviewBody = "Real awful fake food!";
            testaurant.Reviews.Add(testReview1);
            testaurant.Reviews.Add(testReview2);
            testList.Add(testaurant);
            string returnString = test.SerializeRestaurants(testList);
            Assert.AreEqual(@"[{""ID"":0,""restName"":""fakeRestName"",""restAddress"":""fakeAddress"",""locality"":""land o fakes"",""city"":""fakeCity"",""latitude"":""fake"",""longitude"":""fake"",""zipcode"":""12345"",""cuisines"":""fakeCuisine"",""Reviews"":[{""ID"":1,""RestID"":0,""reviewer"":""john fakeman"",""rating"":5,""reviewBody"":""Real fake food!"",""Restaurant"":null},{""ID"":2,""RestID"":0,""reviewer"":""jenny fakewoman"",""rating"":1,""reviewBody"":""Real awful fake food!"",""Restaurant"":null}]}]", returnString);

        }

        [TestMethod()]
        public void DeserializeRestaurantsTest()
        {
            Serializer test = new Serializer();
            List<Restaurant> testList = new List<Restaurant>();
            Restaurant testaurant = new Restaurant(); testaurant.ID = 0; testaurant.restName = "fakeRestName"; testaurant.city = "fakeCity"; testaurant.latitude = "fake"; testaurant.longitude = "fake"; testaurant.locality = "land o fakes"; testaurant.ID = 0; testaurant.restAddress = "fakeAddress"; testaurant.cuisines = "fakeCuisine"; testaurant.zipcode = "12345";
            Review testReview1 = new Review(); testReview1.rating = 5; testReview1.RestID = testaurant.ID; testReview1.ID = 1; testReview1.reviewer = "john fakeman"; testReview1.reviewBody = "Real fake food!";
            Review testReview2 = new Review(); testReview2.rating = 1; testReview2.RestID = testaurant.ID; testReview2.ID = 2; testReview2.reviewer = "jenny fakewoman"; testReview2.reviewBody = "Real awful fake food!";
            testaurant.Reviews.Add(testReview1);
            testaurant.Reviews.Add(testReview2);
            testList.Add(testaurant);
            string returnString = test.SerializeRestaurants(testList);
            List<Restaurant> testList2 = test.DeserializeRestaurants(returnString);
            Assert.AreEqual(testList[0].restName,testList2[0].restName);
            Assert.AreEqual(testList[0].Reviews.ElementAt(0).reviewer, testList[0].Reviews.ElementAt(0).reviewer);
        }
    }
}