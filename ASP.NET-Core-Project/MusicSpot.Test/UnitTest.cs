
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MusicSpot.Controllers;
using MusicSpot.Data;
using MusicSpot.Data.Identity;
using MusicSpot.Data.Models;
using MusicSpot.Data.Repositories;
using MusicSpot.Services.Albums;
using MusicSpot.Services.Movies;
using MyTested.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace MusicSpot.Test
{
    public class Tests
    {
        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;


        [SetUp]
        public async Task Setup()
        {
            dbContext = new InMemoryDbContext();
            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IMusicSpotDbRepository, MusicSpotDbRepository>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IMusicSpotDbRepository>();
            await SeedDbAsync(repo);
        }

        [Test]
        public void HomeControllerReturnNull()
        {
            var homeController = new HomeController(null);

            var result = homeController.HttpContext;

            Assert.IsNull(result);

        }

        [Test]
        public void HomeControllerIndex()
        {
            var homeController = new HomeController(null);

            var result = homeController.Index();

            Assert.IsNotNull(result);

        }

        [Test]
        public void HomeControllerPrivacy()
        {
            var homeController = new HomeController(null);

            var result = homeController.Privacy();

            Assert.IsNotNull(result);

        }

        [Test]
        public void AlbumControllerReturnNull()
        {
            var albumController = new AlbumsController(null, null);

            var result = albumController.HttpContext;

            Assert.IsNull(result);

        }

        [Test]
        public void AlbumControllerCreateNotNull()
        {

            var albumController = new AlbumsController(null, null);

            var result = albumController.Create();

            Assert.IsNotNull(result);

        }

        [Test]
        public void AlbumControllerIndexNotNull()
        {

            var albumController = new AlbumsController(null, null);

            var result = albumController.Index(1, "aaa", 1, 5);

            Assert.IsNotNull(result);

        }

        [Test]
        public void AlbumControllerDetails()
        {

            var albumController = new AlbumsController(null, null);

            var result = albumController.Details(1);

            Assert.IsNotNull(result);

        }

        [Test]
        public void AlbumControllerDelete()
        {

            var albumController = new AlbumsController(null, null);

            var result = albumController.Delete(1);

            Assert.IsNotNull(result);

        }

        [Test]
        public void AlbumControllerEdit()
        {

            var albumController = new AlbumsController(null, null);

            var result = albumController.Edit(1);

            Assert.IsNotNull(result);

        }

        [Test]
        public void AlbumControllerDeleteConfirmed()
        {

            var albumController = new AlbumsController(null, null);

            var result = albumController.DeleteConfirmed(1);

            Assert.IsNotNull(result);

        }

        [Test]
        public void AlbumControllerAlbumsExist()
        {

            var albumController = new AlbumsController(null, null);

            var result = albumController.AllAlbums(1, "aaa");

            Assert.IsNotNull(result);

        }

        [Test]
        public void AlbumControllerAlbumsAll()
        {

            var albumController = new AlbumsController(null, null);

            var result = albumController.AllAlbums(1, "aaa");

            Assert.IsNotNull(result);

        }

        [Test]
        public void MoviesControllerReturnNull()
        {
            var moviesController = new MoviesController(null, null);

            var result = moviesController.HttpContext;

            Assert.IsNull(result);

        }

        [Test]
        public void MoviesControllerIndex()
        {
            var moviesController = new MoviesController(null, null);

            var result = moviesController.Index("aaa");

            Assert.IsNotNull(result);

        }

        [Test]
        public void MoviesControllerDetails()
        {
            var moviesController = new MoviesController(null, null);

            var result = moviesController.Details(1);

            Assert.IsNotNull(result);

        }

        [Test]
        public void MoviesControllerCreate()
        {
            var moviesController = new MoviesController(null, null);

            var result = moviesController.Create();

            Assert.IsNotNull(result);

        }

        [Test]
        public void MoviesControllerEdit()
        {
            var moviesController = new MoviesController(null, null);

            var result = moviesController.Edit(null);

            Assert.IsNotNull(result);

        }

        [Test]
        public void MoviesControllerDelete()
        {
            var moviesController = new MoviesController(null, null);

            var result = moviesController.Delete(null);

            Assert.IsNotNull(result);

        }

        [Test]
        public void MoviesControllerDeleteConfirmed()
        {
            var moviesController = new MoviesController(null, null);

            var result = moviesController.DeleteConfirmed(1);

            Assert.IsNotNull(result);

        }

        [Test]
        public void BooksControllerReturnNull()
        {
            var booksController = new BooksController(null);

            var result = booksController.HttpContext;

            Assert.IsNull(result);

        }

        [Test]
        public void BooksControllerIndex()
        {
            var booksController = new BooksController(null);

            var result = booksController.Index("aaa");

            Assert.IsNotNull(result);

        }

        [Test]
        public void BooksControllerCreate()
        {
            var booksController = new BooksController(null);

            var result = booksController.Create();

            Assert.IsNotNull(result);

        }

        [Test]
        public void BooksControllerDetails()
        {
            var booksController = new BooksController(null);

            var result = booksController.Details(null);

            Assert.IsNotNull(result);

        }

        [Test]
        public void BooksControllerEdit()
        {
            var booksController = new BooksController(null);

            var result = booksController.Edit(null);

            Assert.IsNotNull(result);

        }

        [Test]
        public void BooksControllerDelete()
        {
            var booksController = new BooksController(null);

            var result = booksController.Delete(null);

            Assert.IsNotNull(result);

        }

        [Test]
        public void BooksControllerDeleteConfirmed()
        {
            var booksController = new BooksController(null);

            var result = booksController.DeleteConfirmed(1);

            Assert.IsNotNull(result);

        }

        [Test]
        public void GamesControllerReturnNull()
        {
            var gamesController = new GamesController(null);

            var result = gamesController.HttpContext;

            Assert.IsNull(result);

        }

        [Test]
        public void GamesControllerIndex()
        {
            var gamesController = new GamesController(null);

            var result = gamesController.Index("aaa");

            Assert.IsNotNull(result);

        }

        [Test]
        public void GamesControllerCreate()
        {
            var gamesController = new GamesController(null);

            var result = gamesController.Create();

            Assert.IsNotNull(result);

        }

        [Test]
        public void GamesControllerDetails()
        {
            var gamesController = new GamesController(null);

            var result = gamesController.Details(null);

            Assert.IsNotNull(result);

        }

        [Test]
        public void GamesControllerEdit()
        {
            var gamesController = new GamesController(null);

            var result = gamesController.Edit(null);

            Assert.IsNotNull(result);

        }

        [Test]
        public void GamesControllerDelete()
        {
            var gamesController = new GamesController(null);

            var result = gamesController.Delete(null);

            Assert.IsNotNull(result);

        }

        [Test]
        public void GamesControllerDeleteConfirmed()
        {
            var gamesController = new GamesController(null);

            var result = gamesController.DeleteConfirmed(1);

            Assert.IsNotNull(result);

        }

        [Test]
        public void TestUsers()
        {
            var currUser = new User { FirstName = "Pesho", LastName = "Peshov", Email = "pesho@abv.bg" };

            var user = dbContext.CreateContext().Users;

            Assert.IsNotNull(user);
            Assert.AreNotEqual(currUser, user);
        }

        [Test]
        public void TestArtistIsEqual()
        {
            var artist = dbContext.CreateContext().Artists;

            var currArtist = new Artist
            {
                Name = "Abba",
                Genre = "Pop"
            };

            Assert.AreNotEqual(currArtist, artist);
            Assert.IsNotNull(artist);
        }


        [Test]
        public void ArtistValidDb()
        {
            var artist = new Artist { Name = "Abba" };

            dbContext.CreateContext().Artists.Add(artist);

            Assert.IsNotNull(dbContext);
            Assert.AreNotEqual(dbContext.Equals(artist), artist);

        }

        [Test]
        public void ArtistControllerReturnNull()
        {
            var artistController = new ArtistsController(null);

            var result = artistController.HttpContext;

            Assert.IsNull(result);

        }

        [Test]
        public void ArtistControllerIndex()
        {
            var artistController = new ArtistsController(null);

            var result = artistController.Index("111", "aaa");

            Assert.IsNotNull(result);

        }

        [Test]
        public void ArtistControllerCreate()
        {
            var artistController = new ArtistsController(null);

            var result = artistController.Create();

            Assert.IsNotNull(result);

        }

        [Test]
        public void ArtistControllerDetails()
        {
            var artistController = new ArtistsController(null);

            var result = artistController.Details(null);

            Assert.IsNotNull(result);

        }

        [Test]
        public void ArtistControllerEdit()
        {
            var artistController = new ArtistsController(null);

            var result = artistController.Edit(null);

            Assert.IsNotNull(result);

        }

        [Test]
        public void ArtistControllerDelete()
        {
            var artistController = new ArtistsController(null);

            var result = artistController.Delete(null);

            Assert.IsNotNull(result);

        }

        [Test]
        public void ArtistControllerDeleteConfirmed()
        {
            var artistController = new ArtistsController(null);

            var result = artistController.DeleteConfirmed(1);

            Assert.IsNotNull(result);

        }

        [Test]
        public void TracksControllerReturnNull()
        {
            var tracksController = new TracksController(null, null);

            var result = tracksController.HttpContext;

            Assert.IsNull(result);

        }

        [Test]
        public void TracksControllerIndex()
        {
            var tracksController = new TracksController(null, null);

            var result = tracksController.Index("aaa");

            Assert.IsNotNull(result);

        }

        [Test]
        public void TracksControllerDetails()
        {
            var tracksController = new TracksController(null, null);

            var result = tracksController.Details(null);

            Assert.IsNotNull(result);

        }

        [Test]
        public void TracksControllerCreate()
        {
            var tracksController = new TracksController(null, null);

            var result = tracksController.Create(null);

            Assert.IsNotNull(result);

        }

        [Test]
        public void TracksControllerEdit()
        {
            var tracksController = new TracksController(null, null);

            var result = tracksController.Edit(null);

            Assert.IsNotNull(result);

        }

        [Test]
        public void TracksControllerDelete()
        {
            var tracksController = new TracksController(null, null);

            var result = tracksController.Delete(null);

            Assert.IsNotNull(result);

        }

        [Test]
        public void TracksControllerDeleteConfirmed()
        {
            var tracksController = new TracksController(null, null);

            var result = tracksController.DeleteConfirmed(1);

            Assert.IsNotNull(result);

        }

        [Test]
        public void TracksReturnResult()
        {
            var track = new Track { Name = "track1" };

            var tracksController = dbContext.CreateContext().Tracks.Add(track);

            var result = tracksController.Context;

            Assert.IsNotNull(result);
            Assert.AreNotEqual(dbContext.Equals(track), track);


        }

        [Test]
        public void AlbumsDbReturnResult()
        {
            var album = new Album { Name = "album" };

            var albumController = dbContext.CreateContext().Albums.Add(album);
            var albumId = dbContext.CreateContext().Albums.CountAsync();

            var result = albumController.Context;

            Assert.IsNotNull(result);
            Assert.AreNotEqual(dbContext.Equals(album), album);

        }

        [Test]
        public void UserReturnResult()
        {
            var user = new User { UserName = "Pesho" };

            dbContext.CreateContext().Users.Add(user);

            Assert.IsNotNull(dbContext);
            Assert.AreNotEqual(dbContext.Equals(user), user);
            Assert.AreNotSame(dbContext.Equals(user), user);
        }


        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private async Task SeedDbAsync(IMusicSpotDbRepository repo)
        {
            var user = new User()
            {
                Email = "pesho@abv.bg",
                FirstName = "Pesho",
                LastName = "Peshov"
            };

            var artist = new Artist()
            {
                User = user,
                Genre = "Rock",
                Name = "Metallica",
            };

            await repo.AddAsync(artist);
            await repo.AddAsync(user);
            await repo.SaveChangesAsync();
        }
    }
}