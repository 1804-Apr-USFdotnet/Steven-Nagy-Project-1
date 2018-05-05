using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviewsModels;
using Repository;
using System.Text.RegularExpressions;

namespace BusinessLogic
{
    public class RestServices : IRestServ
    {
        private readonly IRestaurantRepository _restaurantRepo;
        public RestServices(IRestaurantRepository restaurantRepo)
        {
            _restaurantRepo = restaurantRepo;
        }

        public void AddRest(Restaurant rest)
        {
            _restaurantRepo.AddRestaurant(rest);
        }

        public List<Restaurant> AllRests()
        {
            return _restaurantRepo.GetAllRestaurants().ToList();
        }

        public void DeleteRest(Restaurant rest)
        {
            _restaurantRepo.DeleteRestaurant(rest);
        }
        public Restaurant GetRestaurantByID(int id)
        {
            return _restaurantRepo.GetById(id);
        }

        public List<Restaurant> SearchAll(string searchName)
        {
            IEnumerable<Restaurant> checkList = _restaurantRepo.GetAllRestaurants().Where(x => Regex.IsMatch(x.restName,searchName));
            return checkList.ToList();
        }

        public List<Restaurant> SortRestaurants(string queryName)
        {
            IEnumerable<Restaurant> checkList = _restaurantRepo.GetAllRestaurants();
            switch(queryName.ToLower())
            {
                case "name":
                    return checkList.OrderBy(x=>x.restName).ToList();
                case "city":
                    return checkList.OrderBy(x => x.city).ToList();
                case "locality":
                    return checkList.OrderBy(x => x.locality).ToList();
                case "address":
                    return checkList.OrderBy(x => x.restAddress).ToList();
                case "cuisines":
                    return checkList.OrderBy(x => x.cuisines).ToList();
                case "zipcode":
                    return checkList.OrderBy(x => x.zipcode).ToList();
                default:
                    return new List<Restaurant>();
            }
        }

        public double getAverageRating(Restaurant rest)
        {
            double averageRating;
            try
            {
                averageRating = Math.Round(rest.Reviews.Select(y => (y.rating.HasValue ? y.rating.Value : 0)).Average(), 2);
            }
            catch (Exception)
            {

                averageRating = 0;
            }
            
            return averageRating;
        }

        public List<Restaurant> TopThreeRests()
        {
            IEnumerable<Restaurant> checkList = _restaurantRepo.GetAllRestaurants();
            return checkList.OrderByDescending(x => getAverageRating(x)).Take(3).ToList();
        }

        public void UpdateRest(Restaurant rest)
        {
            _restaurantRepo.ModifyRestaurant(rest);
        }
    }

    public class RevServices : IRevServ
    {
        private readonly IReviewRepository _reviewRepo;
        public RevServices(IReviewRepository reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }

        public void AddRev(Restaurant rest, Review rev)
        {
            _reviewRepo.AddReview(rest, rev);
        }

        public void DeleteRev(Restaurant rest, Review rev)
        {
            _reviewRepo.DeleteReview(rest, rev);
        }

        public List<Review> GetAllRestReviews(Restaurant rest)
        {
            return _reviewRepo.GetAllReviewsByRestID(rest.ID).ToList();
        }

        public Review GetReviewByRestAndID(Restaurant rest, int ID)
        {
            return _reviewRepo.GetById(rest.ID, ID);
        }

    }
}
