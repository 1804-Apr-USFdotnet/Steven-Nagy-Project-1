using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantReviewsModels;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace Web.Models
{
    public class WebReview
    {
        public int ID { get; set; }

        [Required]
        public int RestID { get; set; }

        [Required]
        public string reviewer { get; set; }

        public Nullable<int> rating { get; set; }

        [Required]
        public string reviewBody { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }

    public class RevMapper : Profile
    {
        public RevMapper()
        {
            CreateMap<Review, WebReview>()
                .ForSourceMember(x => x.ID, y => y.Ignore())
                .ForSourceMember(x => x.RestID, y => y.Ignore())
                .ForSourceMember(x => x.reviewer, y => y.Ignore())
                .ForSourceMember(x => x.reviewBody, y => y.Ignore())
                .ForSourceMember(x => x.rating, y => y.Ignore())
                .ForSourceMember(x => x.Restaurant, y => y.Ignore());


            CreateMap<WebReview, Review>()
                .ForSourceMember(x => x.ID, y => y.Ignore())
                .ForSourceMember(x => x.RestID, y => y.Ignore())
                .ForSourceMember(x => x.reviewer, y => y.Ignore())
                .ForSourceMember(x => x.reviewBody, y => y.Ignore())
                .ForSourceMember(x => x.rating, y => y.Ignore())
                .ForSourceMember(x => x.Restaurant, y => y.Ignore());

        }
    }
}