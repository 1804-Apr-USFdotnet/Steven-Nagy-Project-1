using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using RestaurantReviewsModels;
using Newtonsoft.Json;

namespace BusinessLogic
{
    public class Serializer //currently not hooked up to anything, but serializes a list of restaurants which includes all the accompanying data this program needs.
    {
        public void SerializedToFile(string input)
        {
            System.IO.File.WriteAllText(ConfigurationManager.AppSettings.GetValues("JSONpath")[0], input);
        }
        public List<Restaurant> SerializedFromFile()
        {
            string deser = System.IO.File.ReadAllText(ConfigurationManager.AppSettings.GetValues("JSONpath")[0]);
            return DeserializeRestaurants(deser);
        }

        public string SerializeRestaurants(List<Restaurant> sr) //serializes reviews by proxy, as all reviews only exist attached to restaurants
        {
            string response = JsonConvert.SerializeObject(sr);
            return response;
        }

        public List<Restaurant> DeserializeRestaurants(string serializedJSON)
        {
            List<Restaurant> returnList = JsonConvert.DeserializeObject<List<Restaurant>>(serializedJSON);
            return returnList;
        }
    }
}
