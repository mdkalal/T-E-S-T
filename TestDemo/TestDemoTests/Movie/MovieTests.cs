using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using TestDemo.Domain;
using TestDemo.Data;


namespace TestDemo.Models.Tests
{
    [TestClass]
    public class MovieTests
    {

        private MovieServices _movieServices;
        private MovieReview _movieReview;
        private string _reviewerEmailAddress;

        public void BuildArrange()
        {
            //Set up connection strings, or anything required for integ test
            var _movieDataServices = new MovieDataServices();
            _movieServices = new MovieServices(_movieDataServices);
            _movieReview = new MovieReview();
            _reviewerEmailAddress = "mark@outlook.com";
        }

        //break out different builds-
        //BuildArrangeInvalidReview
        //BuildArrangeSaveReviewError
        // etc


        [TestMethod]
        public void ReorderMovieRatings_AOTCHGreaterThanTESB_ThrowsBadTasteException()
        {
            //Arrange
            List<MovieModel> objOrder = new List<MovieModel>()
            {
                new MovieModel {Id=01, Title="Episode IV - A New Hope", Rating="2"},
                new MovieModel {Id=02, Title="Episode V - The Empire Strikes Back", Rating="3"},
                new MovieModel {Id=05, Title="Episode II - Attack of the Clones", Rating="1"},

            };

            var parms = new ListOfMovies();
            ListOfMovies movieList = new ListOfMovies();
            movieList.Movies = objOrder;

            // Act and assert
            Assert.ThrowsException<BadTasteException>(() => MovieModel.ReOrderMoviesByRatings(movieList));

        }


        [TestMethod]
        public void SaveReview_InsertNewReview_Pass()
        {
            //Arrange
            BuildArrange();

            _movieReview.ReviewText = "Good movie";
            _movieReview.MovieId = 123;
    
            //Act
            var returnMovieReview = _movieServices.SaveReview(_movieReview, _reviewerEmailAddress);

            Assert.IsTrue(returnMovieReview.ReviewId == 1024); 

        }
        
        [TestMethod]
        public void SaveReview_InvalidEmail_ThrowArgumentException()
        {
            //Arrange
            BuildArrange();

            _reviewerEmailAddress = "";

            //Act and Assert
            Assert.ThrowsException<ArgumentException>(() => _movieServices.SaveReview(_movieReview, _reviewerEmailAddress));

        }
    }
}