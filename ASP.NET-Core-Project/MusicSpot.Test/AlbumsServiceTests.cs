using Microsoft.EntityFrameworkCore;
using MusicSpot.Data;
using MusicSpot.Data.Models;
using MusicSpot.Services.Albums;
using NUnit.Framework;

namespace MusicSpot.Test
{
    public class AlbumsServiceTests
    {
        [Test]
        public void AlbumCreateTest()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("ALbumCreateCorrect").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new AlbumService(dbContext);

            var album = new Album
            {
                Name = "Joni",
                ImageUrl = "aaaa",
                Year = 2000,
                Format = "LP",
                MediaCondition = "G+",
                SleeveCondition = "NM",
                Notes = "some notes",
                ArtistId = 7
            };

            var result = service.Create(album.Name, album.ImageUrl, album.Year, album.Format, album.MediaCondition, album.SleeveCondition, album.Notes, album.ArtistId);

            Assert.That(result, Is.Not.Null);
            Assert.AreEqual("G+", album.MediaCondition);
            Assert.That(album.Id, Is.Not.Null);
        }

        [Test]
        public void TestAllAlbums()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("returnAlbumNotNull").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new AlbumService(dbContext);

            var result = service.AllAlbums("aaa", 14, "music", 5, 5);
            Assert.That(result, Is.Not.Null);
            Assert.AreNotEqual("aaaaaa", result.Result.UserId);
            Assert.AreEqual(14, result.Result.ArtistId);
            Assert.AreEqual(5, result.Result.PageSize);
            Assert.AreEqual(5, result.Result.PageNum);
            Assert.AreEqual("music", result.Result.SearchTerm);



        }

        [Test]
        public void TestCreateAlbumsCount()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("createAlbumsReturnCount").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new AlbumService(dbContext);

            var album = new Album
            {
                Name = "Joni",
                ImageUrl = "aaaa",
                Year = 2000,
                Format = "LP",
                MediaCondition = "G+",
                SleeveCondition = "NM",
                Notes = "some notes",
                ArtistId = 7
            };

            for (int i = 1; i < 5; i++)
            {
                service.Create(album.Name, album.ImageUrl, album.Year, album.Format, album.MediaCondition, album.SleeveCondition, album.Notes, album.ArtistId);

                dbContext.SaveChanges();
            }

            dbContext.SaveChanges();

            int result = dbContext.Albums.CountAsync().Result;

            Assert.AreEqual(4, result);
            Assert.That(result, Is.Not.Null);
            Assert.That(album.Id, Is.Not.Null);

            dbContext.Remove(album);

        }

        [Test]
        public void TestAlbumsList()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("albumsListCount").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new AlbumService(dbContext);

            var album = new Album
            {
                Name = "Joni",
                ImageUrl = "aaaa",
                Year = 2000,
                Format = "LP",
                MediaCondition = "G+",
                SleeveCondition = "NM",
                Notes = "some notes",
                ArtistId = 7
            };

            dbContext.Albums.Add(album);
            dbContext.SaveChanges();

            var result = service.AlbumsList("aaa", album.ArtistId);

            Assert.That(result, Is.Not.Null);
            Assert.AreEqual(dbContext.Albums.CountAsync().Result, 1);
            Assert.That(album.Id, Is.Not.Null);

        }

        [Test]
        public void TestAlbumExist()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("albumExist").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new AlbumService(dbContext);

            var album = new Album
            {
                Id = 1,
                Name = "Joni",
                ImageUrl = "aaaa",
                Year = 2000,
                Format = "LP",
                MediaCondition = "G+",
                SleeveCondition = "NM",
                Notes = "some notes",
                ArtistId = 7
            };

            dbContext.Albums.Add(album);
            dbContext.SaveChanges();

            var result = service.AlbumExist(album.Id);

            Assert.AreEqual(result, true);
            Assert.AreNotEqual(result, false);
            Assert.That(album.Id, Is.Not.Null);
        }

        [Test]
        public void TestAlbumDelete()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("albumDelete").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new AlbumService(dbContext);

            var album = new Album
            {
                Id = 1,
                Name = "Joni",
                ImageUrl = "aaaa",
                Year = 2000,
                Format = "LP",
                MediaCondition = "G+",
                SleeveCondition = "NM",
                Notes = "some notes",
                ArtistId = 7
            };

            dbContext.Albums.Add(album);
            dbContext.SaveChanges();

            var result = service.Delete(album.Id);

            Assert.AreEqual(result, true);
            Assert.AreEqual(service.AlbumExist(album.Id), false);
            Assert.AreNotEqual(result, false);
            Assert.That(album.Id, Is.Not.Null);
            Assert.AreEqual(result, true);
        }

        [Test]
        public void TestAlbumEdit()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("albumEditCorrect").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new AlbumService(dbContext);

            var album = new Album
            {
                Name = "Joni",
                ImageUrl = "aaaa",
                Year = 2000,
                Format = "LP",
                MediaCondition = "G+",
                SleeveCondition = "NM",
                Notes = "some notes",
                ArtistId = 7
            };

            dbContext.Albums.Add(album);
            dbContext.SaveChanges();

            var result = service.Edit(album.Id, album.Name = "Joki", album.ImageUrl, album.Year, album.Format, album.MediaCondition, album.SleeveCondition, album.Name, album.ArtistId);

            Assert.AreNotEqual(album, result);
            Assert.AreEqual("Joki", album.Name);
            Assert.That(result, Is.Not.Null);
            Assert.That(album.Id, Is.Not.Null);
            Assert.AreEqual(result, true);
        }

        [Test]
        public void TestAlbumsDetails()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("albumDetails").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new AlbumService(dbContext);

            var album = new Album
            {
                Name = "Joni",
                ImageUrl = "aaaa",
                Year = 2000,
                Format = "LP",
                MediaCondition = "G+",
                SleeveCondition = "NM",
                Notes = "some notes",
                ArtistId = 7
            };

            dbContext.Albums.Add(album);
            dbContext.SaveChanges();

            var result = service.AlbumDetails(album.Id);

            Assert.That(album.Id, Is.Not.Null);
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual("Joni", album.Name);
            Assert.AreEqual(2000, album.Year);
            Assert.AreEqual("some notes", album.Notes);
            Assert.AreNotEqual(8, album.ArtistId);
        }

        [Test]
        public void TestAlbums()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("albumIndex").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new AlbumService(dbContext);

            var album = new Album
            {
                Name = "Joni",
                ImageUrl = "aaaa",
                Year = 2000,
                Format = "LP",
                MediaCondition = "G+",
                SleeveCondition = "NM",
                Notes = "some notes",
                ArtistId = 7
            };

            dbContext.Albums.Add(album);
            dbContext.SaveChanges();

            var result = service.Index("aaa", album.ArtistId, "Joni", 5, 5);

            Assert.That(result, Is.Not.Null);
            Assert.That(album.Id, Is.Not.Null);
            Assert.AreEqual("aaa", result.Result.UserId);
            Assert.AreNotEqual("bbbaaa", result.Result.UserId);
            Assert.AreEqual(7, result.Result.ArtistId);
            Assert.AreNotEqual("aaaa", result.Result.ArtistId);
            Assert.AreNotEqual("aaa", result.Result.SearchTerm);
            Assert.AreEqual("Joni", result.Result.SearchTerm);
            Assert.AreEqual(5, result.Result.PageNum);
            Assert.AreEqual(5, result.Result.PageSize);
            Assert.AreNotEqual("aaa", result.Result.PageNum);
        }

       
    }
}
