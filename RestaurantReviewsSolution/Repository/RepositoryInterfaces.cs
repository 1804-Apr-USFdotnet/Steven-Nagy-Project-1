using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviewsModels;

namespace Repository
{
    public interface IRestaurantRepository
    {
        Restaurant GetById(int id);
        IEnumerable<Restaurant> GetAllRestaurants();
        void AddRestaurant(Restaurant rest);
        void ModifyRestaurant(Restaurant rest);
        void DeleteRestaurant(Restaurant rest);
        void SaveRestaurants();
    }

    public interface IReviewRepository
    {
        Review GetById(int RestId, int RevId);
        IEnumerable<Review> GetAllReviewsByRestID(int id);
        void AddReview(Restaurant rest, Review rev);
        void DeleteReview(Restaurant rest, Review rev);
        void SaveReviews();
    }
}
