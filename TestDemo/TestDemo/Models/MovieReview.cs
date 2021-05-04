using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDemo.Models
{
    public class MovieReview
    {
        public string ReviewText { get; set; }
        public int ReviewId { get; set; }
        public int MovieId { get; set; }
        public string MostRecentReviewerEmailAddress { get; set; }

    }
}
