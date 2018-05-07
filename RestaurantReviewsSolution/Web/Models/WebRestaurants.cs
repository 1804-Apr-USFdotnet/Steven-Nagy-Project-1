using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantReviewsModels;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class WebRestaurants
    {
        public int ID { get; set; }

        [Required]
        public string restName { get; set; }

        [Required]
        public string restAddress { get; set; }

        [Required]
        public string locality { get; set; }

        [Required]
        public string city { get; set; }

        [Required]
        public string latitude { get; set; }

        [Required]
        public string longitude { get; set; }

        [Required]
        public string zipcode { get; set; }

        [Required]
        public string cuisines { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }

    public class RestMapper : Profile
    {
        public RestMapper()
        {
            CreateMap<Restaurant, WebRestaurants>()
                .ForSourceMember(x => x.ID, y => y.Ignore())
                .ForSourceMember(x => x.restName, y => y.Ignore())
                .ForSourceMember(x => x.restAddress, y => y.Ignore())
                .ForSourceMember(x => x.locality, y => y.Ignore())
                .ForSourceMember(x => x.city, y => y.Ignore())
                .ForSourceMember(x => x.latitude, y => y.Ignore())
                .ForSourceMember(x => x.longitude, y => y.Ignore())
                .ForSourceMember(x => x.zipcode, y => y.Ignore())
                .ForSourceMember(x => x.cuisines, y => y.Ignore())
                .ForSourceMember(x => x.Reviews, y => y.Ignore());
                
        }
    }
}