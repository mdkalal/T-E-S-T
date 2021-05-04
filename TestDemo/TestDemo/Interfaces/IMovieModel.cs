using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDemo.Interfaces
{
    public interface IMovieModel2
    {
        int Id { get; set; }
        string Title { get; set; }
        string ImagePath { get; set; }
        string Rating { get; set; }


    }
}
