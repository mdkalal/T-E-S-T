using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestDemo.Models;
using TestDemo.Domain;
using TestDemo.Data;

namespace TestDemo.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowMovie()
        {

            MovieDataServices movieDataServices = new MovieDataServices();
            MovieServices movieServices = new MovieServices(movieDataServices);
            
            List<MovieModel> movies = movieServices.GetMovies();

            ListOfMovies movieList = new ListOfMovies();
            movieList.Movies = movies;

            return View(movieList);

        }

        [HttpPost]
        public IActionResult ShowMovie(ListOfMovies movieListIn)
        {
          
            ListOfMovies movieListOut = new ListOfMovies();

            try
            {
                movieListOut.Movies = MovieModel.ReOrderMoviesByRatings(movieListIn);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(movieListIn);
            }

            ModelState.Clear();

            return View("ShowMovie", movieListOut);

        }
    }
}