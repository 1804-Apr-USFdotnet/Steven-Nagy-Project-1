﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviewsModels;

namespace Repository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RepositoryContext _repoContext;
        public RestaurantRepository(RepositoryContext context)
        {
            _repoContext = context;
        }

        public void AddRestaurant(Restaurant rest)
        {
            _repoContext.Restaurants.Add(rest);
            _repoContext.SaveChanges();
        }

        public void DeleteRestaurant(Restaurant rest)
        {
            Restaurant checkID = _repoContext.Restaurants.Find(rest.ID);
            foreach (var item in rest.Reviews.ToList())
            {
                rest.Reviews.Remove(item);
                _repoContext.Entry(rest).CurrentValues.SetValues(rest);
                _repoContext.SaveChanges();
            }
            _repoContext.Restaurants.Remove(rest);
            _repoContext.SaveChanges();
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return _repoContext.Restaurants;
        }

        public Restaurant GetById(int id)
        {
            return _repoContext.Restaurants.First(x => x.ID == id);
        }

        public void ModifyRestaurant(Restaurant rest)
        {
            Restaurant checkID = _repoContext.Restaurants.Find(rest.ID);
            _repoContext.Entry(checkID).CurrentValues.SetValues(rest);
            _repoContext.SaveChanges();
        }

        public void SaveRestaurants()
        {
            _repoContext.SaveChanges();
        }
    }

    public class ReviewRepository : IReviewRepository
    {
        private readonly RepositoryContext _repoContext;
        public ReviewRepository(RepositoryContext context)
        {
            _repoContext = context;
        }

        public void AddReview(Restaurant rest, Review rev)
        {
            Restaurant checkID = _repoContext.Restaurants.Find(rest.ID);
            rest.Reviews.Add(rev);
            _repoContext.Entry(checkID).CurrentValues.SetValues(rest);
            _repoContext.SaveChanges();
        }

        public void DeleteReview(Restaurant rest, Review rev)
        {
            Restaurant checkID = _repoContext.Restaurants.Find(rest.ID);
            rest.Reviews.Remove(rev);
            _repoContext.Entry(checkID).CurrentValues.SetValues(rest);
            _repoContext.SaveChanges();
        }

        public void ModifyReview(Restaurant rest, Review rev)
        {
            Review checkReview = GetById(rest.ID,rev.ID);
            Restaurant checkRest = _repoContext.Restaurants.Find(rest.ID);
            _repoContext.Entry(checkReview).CurrentValues.SetValues(rev);
            _repoContext.Entry(checkRest).CurrentValues.SetValues(rest);
            _repoContext.SaveChanges();
        }

        public IEnumerable<Review> GetAllReviewsByRestID(int id)
        {
            return _repoContext.Restaurants.Find(id).Reviews;
        }

        public Review GetById(int RestId, int RevId)
        {
            return _repoContext.Restaurants.Find(RestId).Reviews.ElementAt(RevId - 1);
        }

        public void SaveReviews()
        {
            _repoContext.SaveChanges();
        }
    }
}
