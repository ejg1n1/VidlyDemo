using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movies() { Name = "Shrek!"};

            var customers = new List<Customer> {
                new Customer{ Name = "Eugene"},
                new Customer{ Name = "Carina"},
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Movies(int? pageIndex, string sortBy)
        {
            var moviesList = new List<Movies>()
            {
                new Movies{Name = "Shrek"},
                new Movies{Name= "Wall-e"}

            };

            return View(moviesList);
        }

        //[Route("movies/released/{year}/{month:regex(\\d{4}:range(1, 12))}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}
    }
}