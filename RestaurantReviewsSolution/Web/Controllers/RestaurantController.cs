using AutoMapper;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using RestaurantReviewsModels;
using NLog;

namespace Web.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestServ _restServ;
        private readonly IMapper _mapper;
        private static Logger logger = LogManager.GetCurrentClassLogger();

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

        [Route("Restaurant/Details/{id:int}")]
        [HttpGet]
        public ActionResult DetailsRestaurants(int id)
        {
            var viewModel = _mapper.Map<WebRestaurants>(_restServ.GetRestaurantByID(id));

            return View(viewModel);
        }

        [Route("Restaurant/Search")]
        [HttpGet]
        public ActionResult SearchRestaurants(string id)
        {
            IEnumerable<WebRestaurants> viewModel;
            if (id == null) { viewModel = _mapper.Map<IEnumerable<WebRestaurants>>(_restServ.AllRests()); }
            else
            {
                viewModel = _mapper.Map<IEnumerable<WebRestaurants>>(_restServ.SearchAll(id));
            }

            return View(viewModel);
        }

        [Route("Restaurant/SortBy")]
        [HttpGet]
        public ActionResult SortByRestaurants(string id)
        {
            IEnumerable<WebRestaurants> viewModel;
            if (id == null) { viewModel = _mapper.Map<IEnumerable<WebRestaurants>>(_restServ.AllRests()); }
            else
            {
                viewModel = _mapper.Map<IEnumerable<WebRestaurants>>(_restServ.SortRestaurants(id));
            }

            return View(viewModel);
        }

        [Route("Restaurant/Top3")]
        [HttpGet]
        public ActionResult Top3Restaurants()
        {
            var viewModel = _mapper.Map<IEnumerable<WebRestaurants>>(_restServ.TopThreeRests()); 

            return View(viewModel);
        }

        [Route("Restaurant/Add")]
        [HttpGet]
        public ActionResult AddRestaurant()
        {
            return View();
        }

        [Route("Restaurant/Add")]
        [HttpPost]
        public ActionResult AddRestaurant(WebRestaurants add)
        {
            if (!ModelState.IsValid) return View(add);

            var restaurant = _mapper.Map<Restaurant>(add);

            _restServ.AddRest(restaurant);

            return RedirectToAction("AllRestaurants");
        }

        [Route("Restaurant/Edit/{id:int}")]
        [HttpGet]
        public ActionResult EditRestaurant(int id)
        {
            var viewModel = _mapper.Map<WebRestaurants>(_restServ.GetRestaurantByID(id));

            return View(viewModel);
        }

        [Route("Restaurant/Edit/{id:int}")]
        [HttpPost]
        public ActionResult EditRestaurant(WebRestaurants mod)
        {
            try
            {
                Restaurant newModel = new Restaurant();
                _mapper.Map<WebRestaurants, Restaurant>(mod, newModel);
                _restServ.UpdateRest(newModel);
                

                return RedirectToAction("AllRestaurants");
            }
            catch
            {
                return RedirectToAction("AllRestaurants");
            }
        }

        [Route("Restaurant/Delete/{id:int}")]
        [HttpGet]
        public ActionResult DeleteRestaurant(int id)
        {
            var viewModel = _restServ.GetRestaurantByID(id);
            _restServ.DeleteRest(viewModel);

            return RedirectToAction("AllRestaurants");
        }

        // GET: Restaurant
        public ActionResult Index()
        {

            logger.Info("Application started");
            return RedirectToAction("AllRestaurants");
        }
    }
}