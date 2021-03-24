using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieCollection.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Controllers
{
    public class HomeController : Controller
    {
        private MovieDbContext context { get; set; }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, MovieDbContext con)
        {
            _logger = logger;
            context = con;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterFilm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterFilm(Movie movie)
        {
            if (movie.Title == "Independence Day")
            {
                ModelState.AddModelError(string.Empty, "That movie is not valid. Please try any other movie.");
                return View();
            }
            else if (ModelState.IsValid)
            {
                //add movie to database
                context.Movies.Add(movie);
                context.SaveChanges();
                return View("FilmList", context.Movies);
            }
            else
            {
                //This will include basic error messages given from the model
                return View();
            }

        }

        public IActionResult FilmList()
        {
            return View(context.Movies);
        }


        [HttpGet]
        public IActionResult EditFilm(int movieId)
        {
            Movie movie = context.Movies.FirstOrDefault(m => m.MovieId == movieId);

            return View(movie);
        }

        [HttpPost]
        public IActionResult EditFilm(Movie movie)
        {
            if (movie.Title == "Independence Day")
            {
                ModelState.AddModelError(string.Empty, "That movie is not valid. Please try any other movie.");
                return View();
            }
            else if (ModelState.IsValid)
            {
                //update movie in database
                context.Movies.Update(movie);
                context.SaveChanges();
                return View("FilmList", context.Movies);
            }
            else
            {
                //This will include basic error messages given from the model
                return View();
            }
        }



        //receives the movie id from the form, deletes that entry, and saves the changes to the database
        [HttpPost]
        public IActionResult DeleteFilm(int movieId)
        {
            context.Movies.Remove(context.Movies.FirstOrDefault(m => m.MovieId == movieId));
            context.SaveChanges();

            return View("FilmList", context.Movies);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
