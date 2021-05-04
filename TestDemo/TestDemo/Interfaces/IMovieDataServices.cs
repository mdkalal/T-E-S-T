using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDemo.Models;
using TestDemo.Domain;

namespace TestDemo.Interfaces
{
    public interface IMovieDataServices
    {
        public int SaveReviewtoDatabase(MovieReview movieReview, string reviewerEmailAddress, ReviewSaveMode saveMode);
    }

}
