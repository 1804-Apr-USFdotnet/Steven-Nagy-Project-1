using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using RestaurantReviewsModels;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext() : base("name=RestaurantReviewsDBEntities")
        {
            
        }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
