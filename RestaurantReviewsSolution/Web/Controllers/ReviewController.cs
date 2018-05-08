using AutoMapper;
using BusinessLogic;
using RestaurantReviewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IRestServ _restServ;
        private readonly IRevServ _revServ;
        private readonly IMapper _mapper;

        public ReviewController(IRestServ restServ, IRevServ revServ, IMapper mapper)
        {
            _restServ = restServ;
            _revServ = revServ;
            _mapper = mapper;
        }

        [Route("Review/Add/{id:int}")]
        [HttpGet]
        public ActionResult AddReview(int id)
        {
            //var revModel = _restServ.GetRestaurantByID(id);
            //WebReview viewModel = new WebReview();
            //viewModel.Restaurant = revModel;
            ViewBag.ID = id;
            return View();
        }

        [Route("Review/Add/{id:int}")]
        [HttpPost]
        public ActionResult AddReview(WebReview addRev, int RestModelID)
        {
            if (!ModelState.IsValid) return View(addRev);

            var restaurant = _restServ.GetRestaurantByID(RestModelID);
            var review = _mapper.Map<Review>(addRev);
            review.RestID = restaurant.ID;
            review.ID = restaurant.Reviews.Max(x => x.ID) + 1;

            _revServ.AddRev(restaurant,review);

            return RedirectToAction("AllRestaurants","Restaurant",null);
        }

        [Route("Review/Delete")]
        [HttpGet]
        public ActionResult DeleteReview(int restId,int revId)
        {
            var restModel = _restServ.GetRestaurantByID(restId);
            var revModel = _revServ.GetReviewByRestAndID(restModel, revId);
            _revServ.DeleteRev(restModel,revModel);

            return RedirectToAction("AllRestaurants", "Restaurant", null);
        }

        [Route("Review/Edit")]
        [HttpGet]
        public ActionResult EditReview(int restId, int revId)
        {
            var restModel = _restServ.GetRestaurantByID(restId);
            var revModel = _mapper.Map<WebReview>(_revServ.GetReviewByRestAndID(restModel,revId));
            return View(revModel);
        }

        [Route("Review/Edit")]
        [HttpPost]
        public ActionResult EditReview(WebReview rev, int restId)
        {
            var restModel = _restServ.GetRestaurantByID(restId);
            Review revModel = new Review();
            _mapper.Map<WebReview,Review>(rev,revModel);
            _revServ.UpdateRev(restModel, revModel);

            return RedirectToAction("AllRestaurants", "Restaurant", null);
        }


        // GET: Review
        public ActionResult Index()
        {
            return View();
        }
    }
}