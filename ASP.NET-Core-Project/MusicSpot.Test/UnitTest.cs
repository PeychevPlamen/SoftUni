
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
        public void AlbumControllerReturnNull()
        {
            var albumController = new AlbumsController(null);

            var result = albumController.HttpContext;

            Assert.IsNull(result);

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
            var artistController = new ArtistsController(null, null);

            var result = artistController.HttpContext;

            Assert.IsNull(result);

        }

        [Test]
        public void TracksControllerReturnNull()
        {
            var tracksController = new TracksController(null);

            var result = tracksController.HttpContext;

            Assert.IsNull(result);

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
            Assert.AreEqual(albumId.Id, 1);

        }

        [Test]
        public void UserReturnResult()
        {
            var user = new User { UserName = "Pesho" };

            dbContext.CreateContext().Users.Add(user);

            Assert.IsNotNull(dbContext);
            Assert.AreNotEqual(dbContext.Equals(user), user);

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