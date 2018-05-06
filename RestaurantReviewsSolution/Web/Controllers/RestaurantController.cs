using AutoMapper;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using RestaurantReviewsModels;

namespace Web.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestServ _restServ;
        private readonly IMapper _mapper;
        
        public RestaurantController(IRestServ restServ, IMapper mapper)
        {
            _restServ = restServ;
            _mapper = mapper;
        }

        [Route("Restaurant/All")]
        [HttpGet]
        public ActionResult AllRestaurants()
        {
            var viewModel = _mapper.Map<IEnumerable<WebRestaurants>>(_restServ.AllRests());

            return View(viewModel);
        }

        [Route("Restaurant/Add")]
        [HttpGet]
        public ActionResult AddRestaurant()
        {
            return View();
        }

        // GET: Restaurant
        public ActionResult Index()
        {
            return View();
        }
    }
}