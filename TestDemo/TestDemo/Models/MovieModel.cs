using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDemo.Controllers;
using TestDemo.Interfaces;
using TestDemo.Domain;

namespace TestDemo.Models
{

    public class ListOfMovies
    {
     
        public List<MovieModel> Movies { get; set; }
    }

    public class MovieModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Rating { get; set; }

        public IEnumerable<MovieModel> Movies { get; set; }


        public static List<MovieModel> ReOrderMoviesByRatings(ListOfMovies movieList)
        {

            int clonesRate;
            int empireRate;

            var result = movieList.Movies.Find(x => x.Title.Contains("Empire"));
            empireRate = Convert.ToInt32(result.Rating);

            result = movieList.Movies.Find(x => x.Title.Contains("Clones"));
            clonesRate = Convert.ToInt32(result.Rating);

            if (clonesRate < empireRate)
            {
                throw new BadTasteException("Bad taste exception - There's NO WAY that Attack of the Clones is a better film than The Empire Stricks Back!");
            }

            movieList.Movies.Sort((x, y) => x.Rating.CompareTo(y.Rating));

            return movieList.Movies;
        }
    }
}
