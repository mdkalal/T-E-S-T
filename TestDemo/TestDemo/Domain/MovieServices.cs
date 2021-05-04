using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TestDemo.Data;
using TestDemo.Models;
using TestDemo.Interfaces;

namespace TestDemo.Domain
{
    public class MovieServices
    {

        private IMovieDataServices _movieDataServices;

        public MovieServices(IMovieDataServices movieDataServices)
        {
            _movieDataServices = movieDataServices;

        }


        public List<MovieModel> GetMovies()
        {
            List<MovieModel> movieList = new List<MovieModel>()
            {
                new MovieModel {Id=01, ImagePath = "anewhope.jpg", Title="A New Hope", Rating=""},
                new MovieModel {Id=02, ImagePath = "empirestrikesback.jpg", Title="The Empire Strikes Back", Rating=""},
                new MovieModel {Id=03, ImagePath = "returnofthejedi.jpg", Title="Return of the Jedi", Rating=""},
                new MovieModel {Id=04, ImagePath = "phantommenace.jpg", Title="The Phantom Menace", Rating=""},
                new MovieModel {Id=05, ImagePath = "attackclones.jpg", Title="Attack of the Clones", Rating=""},
                new MovieModel {Id=06, ImagePath = "revengesith.jpg", Title="Revenge of the Sith", Rating=""}
            };

            return movieList;
        }


        public MovieReview SaveReview(MovieReview movieReview, string reviewerEmailAddress)
        {

            int reviewId;

            //Validate
            if (IsValidEmailFormat(reviewerEmailAddress) == false)
            {
                throw new ArgumentException(nameof(reviewerEmailAddress), "Email Address is missing or invalid");
            }

            if (movieReview is null)
            { 
                throw new ArgumentNullException(nameof(movieReview), "Review is required");
            }

            //Save review
            // GetrReviewSaveMode- If movie review id is 0, that means new review.  If not, update to existing review.
            reviewId = _movieDataServices.SaveReviewtoDatabase(movieReview, reviewerEmailAddress, GetReviewSaveMode(movieReview.ReviewId));

            if (reviewId > 0)
            {
                movieReview.MostRecentReviewerEmailAddress = reviewerEmailAddress;
                movieReview.ReviewId = reviewId;
            }

            return movieReview;
        }


        private bool IsValidEmailFormat(string emailAddress)
        {
            var regex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            return Regex.IsMatch(emailAddress, regex, RegexOptions.IgnoreCase);
        }


        private ReviewSaveMode GetReviewSaveMode(int ReviewId)
        {
            if (ReviewId == 0)
            {
                return ReviewSaveMode.ReviewInsert;  
            }
            return ReviewSaveMode.ReviewUpdate;  
        } 

    }
    public enum ReviewSaveMode
    {
        ReviewInsert,
        ReviewUpdate

    }
    public class BadTasteException : Exception
    {
        public BadTasteException()
        {
        }

        public BadTasteException(string message)
            : base(message)
        {
        }

        public BadTasteException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

}
