using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDemo.Domain;
using TestDemo.Interfaces;
using TestDemo.Models;

namespace TestDemo.Data
{
    public class MovieDataServices : IMovieDataServices
    {
        public int SaveReviewtoDatabase(MovieReview movieReview, string reviewerEmailAddress, ReviewSaveMode saveMode)
        {

            if (saveMode == ReviewSaveMode.ReviewInsert)
            {
                // Insert review, return new Review ID - let's say 1024
                return 1024;
            }
            else if(saveMode == ReviewSaveMode.ReviewUpdate)
            {
                // Update review, return existing review ID
                return movieReview.ReviewId; 
            }

            // Else return 0 for error condition
            return 0;
        }

    }
}
