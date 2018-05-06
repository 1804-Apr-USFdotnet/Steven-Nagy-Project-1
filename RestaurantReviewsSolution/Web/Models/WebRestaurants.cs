using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantReviewsModels;

namespace Web.Models
{
    public class WebRestaurants
    {
        public int ID { get; set; }
        public string restName { get; set; }
        public string restAddress { get; set; }
        public string locality { get; set; }
        public string city { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string zipcode { get; set; }
        public string cuisines { get; set; }
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
                .ForSourceMember(x => x.cuisines, y => y.Ignore());
        }
    }
}