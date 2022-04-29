using Microsoft.EntityFrameworkCore;
using MusicSpot.Data;
using MusicSpot.Data.Models;
using MusicSpot.Services.Artists;
using NUnit.Framework;


namespace MusicSpot.Test
{
    public class ArtistServiceTests
    {
        [Test]
        public void TestAllArtist()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("returnArtistNotNull").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new ArtistService(dbContext);

            var result = service.AllArtists("aaa", "metal", 1, 1);
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual("aaa", result.Result.UserId);
            Assert.AreEqual("metal", result.Result.SearchTerm);
            Assert.AreNotEqual("rock", result.Result.SearchTerm);
            Assert.AreEqual(1, result.Result.PageNum);
            Assert.AreEqual(1, result.Result.PageSize);

        }

        [Test]
        public void TestCreateArtist()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("createArtistsReturnCount").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new ArtistService(dbContext);

            var artist = new Artist
            {
                Name = "joni",
                Genre = "metal",
                UserId = "jshsdjhdajdh"
            };

            var result = service.Create(artist.Name, artist.Genre, artist.UserId);

            Assert.That(result, Is.Not.Null);

        }

        [Test]
        public void TestCreateArtistCount()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("createArtistsReturnCount").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new ArtistService(dbContext);

            var artist = new Artist
            {
                Name = "joni",
                Genre = "metal",
                UserId = "jshsdjhdajdh"
            };

            for (int i = 1; i < 5; i++)
            {
                service.Create(artist.Name, artist.Genre, artist.UserId);

                dbContext.SaveChanges();
            }

            dbContext.SaveChanges();

            int result = dbContext.Artists.CountAsync().Result;

            Assert.AreEqual(5, result);

        }

        [Test]
        public void TestArtistList()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("artistListCount").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new ArtistService(dbContext);

            var artist = new Artist
            {
                Name = "joni",
                Genre = "metal",
                UserId = "jshsdjhdajdh"
            };

            dbContext.Artists.Add(artist);
            dbContext.SaveChanges();

            var result = service.ArtistsList;

            Assert.That(result, Is.Not.Null);

        }

        [Test]
        public void TestArtistExist()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("artistExist").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new ArtistService(dbContext);

            var artist = new Artist
            {
                Name = "joni",
                Genre = "metal",
                UserId = "aaaaabbbb"
            };

            dbContext.Artists.Add(artist);
            dbContext.SaveChanges();

            var result = service.ArtistExist(artist.Id);

            Assert.AreEqual(result, true);
            Assert.AreNotEqual(result, false);
            Assert.That(artist.Id, Is.Not.Null);
        }

        [Test]
        public void TestArtistDelete()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("artistDelete").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new ArtistService(dbContext);

            var artist = new Artist
            {
                Name = "joni",
                Genre = "metal",
                UserId = "aaaaabbbb"
            };

            dbContext.Artists.Add(artist);
            dbContext.SaveChanges();

            var result = service.Delete(artist.Id);

            Assert.AreEqual(result, true);
            Assert.AreEqual(service.ArtistExist(artist.Id), false);
            Assert.AreNotEqual(result, false);
            Assert.That(artist.Id, Is.Not.Null);
        }

        [Test]
        public void TestArtistEdit()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("artistEdit").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new ArtistService(dbContext);

            var artist = new Artist
            {
                Name = "joni",
                Genre = "metal",
                UserId = "aaaaabbbb"
            };

            dbContext.Artists.Add(artist);
            dbContext.SaveChanges();

            var result = service.Edit(artist.Id, artist.Name = "Joki", artist.Genre = "rock");

            Assert.AreNotEqual(artist, result);
            Assert.AreEqual("Joki", artist.Name);
            Assert.That(result, Is.Not.Null);
            Assert.That(artist.Id, Is.Not.Null);
        }

        [Test]
        public void TestArtistDetails()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("artistDetails").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new ArtistService(dbContext);

            var artist = new Artist
            {
                Name = "joni",
                Genre = "metal",
                UserId = "aaaaabbbb"
            };

            dbContext.Artists.Add(artist);
            dbContext.SaveChanges();

            var result = service.ArtistDetails(artist.Id);

            Assert.AreEqual(artist.Genre, result.Result.Genre);
            Assert.AreEqual("joni", artist.Name);
            Assert.That(result, Is.Not.Null);
            Assert.That(artist.Id, Is.Not.Null);
        }

        [Test]
        public void TestArtistNotExit()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("artistNotExist").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new ArtistService(dbContext);

            var artist = new Artist
            {
                Id = 1,
                Name = "Joni",
                Genre = "Horror",
                UserId = "aaa"
            };

            dbContext.Artists.Add(artist);
            dbContext.SaveChanges();

            var result = service.ArtistDetails(artist.Id);

            Assert.That(artist.Id, Is.Not.Null);
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual(result.Result.Genre, artist.Genre);
            Assert.AreEqual(result.Result.Name, artist.Name);
            Assert.AreEqual(result.Result.Id, artist.Id);

        }
    }
}
