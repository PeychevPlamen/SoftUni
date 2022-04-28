using Microsoft.EntityFrameworkCore;
using MusicSpot.Data;
using MusicSpot.Data.Models;
using MusicSpot.Services.Movies;
using NUnit.Framework;

namespace MusicSpot.Test
{
    public class MovieServiceTests
    {

        [Test]
        public void MovieCreateTest()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("MovieCreateCorrect").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new MovieService(dbContext);

            var movie = new Movie
            {
                Title = "Speed",
                Genre = "Action",
                ImageUrl = "aaa",
                Year = 1998,
                Description = "some description",
                UserId = "aaa"
            };

            var result = service.Create(movie.Title, movie.Genre, movie.ImageUrl, movie.Year, movie.Description, movie.UserId);

            Assert.That(result, Is.Not.Null);
            Assert.AreEqual("Speed", movie.Title);
            Assert.AreEqual(1, result);
            Assert.That(movie.Id, Is.Not.Null);

        }

        [Test]
        public void TestAllMovies()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("returnMoviesNotNull").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new MovieService(dbContext);

            var movie = new Movie
            {
                Title = "Speed",
                Genre = "Action",
                ImageUrl = "aaa",
                Year = 1998,
                Description = "some description",
                UserId = "aaa"
            };

            var result = service.AllMovies(movie.UserId, "action", 5, 5);

            Assert.That(result, Is.Not.Null);
            Assert.AreEqual("aaa", result.Result.UserId);
            Assert.AreNotEqual(14, result.Result.UserId);
            Assert.AreEqual("action", result.Result.SearchTerm);
            Assert.AreNotEqual("actionssss", result.Result.SearchTerm);
            Assert.AreEqual(5, result.Result.PageSize);
            Assert.AreEqual(5, result.Result.PageNum);
            Assert.AreNotEqual("ccc", result.Result.PageNum);

        }

        [Test]
        public void TestCreateMovieCount()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("createMovieReturnCount").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new MovieService(dbContext);

            var movie = new Movie
            {
                Title = "Speed",
                Genre = "Action",
                ImageUrl = "aaa",
                Year = 1998,
                Description = "some description",
                UserId = "aaa"
            };

            for (int i = 1; i < 5; i++)
            {
                service.Create(movie.Title, movie.Genre, movie.ImageUrl, movie.Year, movie.Description, movie.UserId);

                dbContext.SaveChanges();
            }

            dbContext.SaveChanges();

            int result = dbContext.Movies.CountAsync().Result;

            Assert.AreEqual(4, result);
            Assert.AreNotEqual(14, result);
            Assert.AreNotEqual("aa", result);
            Assert.That(result, Is.Not.Null);
            Assert.That(movie.Id, Is.Not.Null);

            dbContext.Remove(movie);

        }


        [Test]
        public void TestMovieExist()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("movieExist").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new MovieService(dbContext);

            var movie = new Movie
            {
                Id = 1,
                Title = "Speed",
                Genre = "Action",
                ImageUrl = "aaa",
                Year = 1998,
                Description = "some description",
                UserId = "aaa"
            };

            var result = service.MovieExist(1);

            Assert.AreEqual(result, false);
            Assert.AreNotEqual(result, true);
            Assert.That(movie.Id, Is.Not.Null);
        }

        [Test]
        public void TestMovieDelete()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("movieDelete").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new MovieService(dbContext);

            var movie = new Movie
            {
                Id = 1,
                Title = "Speed",
                Genre = "Action",
                ImageUrl = "aaa",
                Year = 1998,
                Description = "some description",
                UserId = "aaa"
            };

            dbContext.Movies.Add(movie);
            dbContext.SaveChanges();

            var result = service.Delete(1);

            Assert.AreEqual(result, true);
            Assert.AreEqual(service.MovieExist(1), false);
            Assert.AreNotEqual(result, false);
            Assert.That(movie.Id, Is.Not.Null);
        }

        [Test]
        public void TestMovieEdit()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("movieEditCorrect").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new MovieService(dbContext);

            var movie = new Movie
            {
                Id = 1,
                Title = "Speed",
                Genre = "Action",
                ImageUrl = "aaa",
                Year = 1998,
                Description = "some description",
                UserId = "aaa"
            };

            dbContext.Movies.Add(movie);
            dbContext.SaveChanges();

            var result = service.Edit(movie.Id, movie.Title, movie.Genre, movie.ImageUrl, movie.Year, movie.Description);

            Assert.AreNotEqual(movie, result);
            Assert.AreEqual("Speed", movie.Title);
            Assert.AreNotEqual("Fifa", movie.Title);
            Assert.That(result, Is.Not.Null);
            Assert.That(movie.Id, Is.Not.Null);
            Assert.AreEqual(result, true);
        }

        [Test]
        public void TestMovieDetails()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("movieDetails").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new MovieService(dbContext);

            var movie = new Movie
            {
                Id = 1,
                Title = "Speed",
                Genre = "Action",
                ImageUrl = "aaa",
                Year = 1998,
                Description = "some description",
                UserId = "aaa"
            };

            dbContext.Movies.Add(movie);
            dbContext.SaveChanges();

            var result = service.MovieDetails(1);

            Assert.That(movie.Id, Is.Not.Null);
            Assert.That(result, Is.Not.Null);
            Assert.AreNotEqual("FIFA", result.Result.Title);
            Assert.AreNotEqual("Sport", result.Result.Genre);
            Assert.AreEqual("some description", result.Result.Description);
            Assert.AreEqual("Speed", result.Result.Title);
            Assert.AreNotEqual(1988, result.Result.Year);
            Assert.AreEqual(1998, result.Result.Year);
            Assert.AreNotEqual(8, result.Result.Id);
            
        }
    }
}
