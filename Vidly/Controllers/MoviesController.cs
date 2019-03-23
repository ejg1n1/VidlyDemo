using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public ApplicationDbContext _context { get; set; }

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(e => e.Genre).ToList();

            return View(movies);
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

        [Route("movies/details/{index}")]
        public ActionResult Details(int index)
        {
            var movie = _context.Movies.Include(e => e.Genre).SingleOrDefault(e => e.Id == index);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
    }
}