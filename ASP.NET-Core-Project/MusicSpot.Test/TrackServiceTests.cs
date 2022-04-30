using Microsoft.EntityFrameworkCore;
using MusicSpot.Data;
using MusicSpot.Data.Models;
using MusicSpot.Services.Tracks;
using NUnit.Framework;

namespace MusicSpot.Test
{
    public class TrackServiceTests
    {
        [Test]
        public void TrackCreateTest()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("TrackCreateCorrect").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new TrackService(dbContext);

            var track = new Track
            {
                Name = "Joni",
                Duration = "4:44",
                AlbumId = 4

            };

            var result = service.Create(track.Name, track.Duration, track.AlbumId);

            Assert.That(result, Is.Not.Null);
            Assert.AreEqual("Joni", track.Name);
            Assert.That(track.Id, Is.Not.Null);
            Assert.AreEqual(1, result);
            
        }

        [Test]
        public void TestAllTracks()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("returnTrackNotNull").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new TrackService(dbContext);

            var track = new Track
            {
                Name = "Joni",
                Duration = "4:44",
                AlbumId = 4

            };

            dbContext.Tracks.Add(track);
            dbContext.SaveChanges();

            var result = service.AllTracks(4);

            Assert.That(result, Is.Not.Null);
            Assert.AreNotEqual("aaaaaa", result.Result.UserId);

        }

        [Test]
        public void TestCreateTrackCount()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("createTracksReturnCount").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new TrackService(dbContext);

            var track = new Track
            {
                Name = "Joni",
                Duration = "4:44",
                AlbumId = 4

            };

            for (int i = 1; i < 5; i++)
            {
                service.Create(track.Name, track.Duration, track.AlbumId);

                dbContext.SaveChanges();
            }

            dbContext.SaveChanges();

            int result = dbContext.Tracks.CountAsync().Result;

            Assert.AreEqual(4, result);
            Assert.AreNotEqual(16, result);
            Assert.AreNotEqual("int", result);
            Assert.That(result, Is.Not.Null);
            Assert.That(track.Id, Is.Not.Null);

            dbContext.Remove(track);

        }


        [Test]
        public void TestTrackExist()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("trackExist").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new TrackService(dbContext);

            var track = new Track
            {
                Id = 1,
                Name = "Joni",
                Duration = "4:44",
                AlbumId = 4

            };

            dbContext.Tracks.Add(track);
            dbContext.SaveChanges();

            var result = service.TrackExist(1);

            Assert.AreNotEqual(result, true);
            Assert.AreEqual(result, false);
            Assert.That(track.Id, Is.Not.Null);
            
        }

        [Test]
        public void TestTrackCount()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("trackCount").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new TrackService(dbContext);

            var track = new Track
            {
                Id = 1,
                Name = "Joni",
                Duration = "4:44",
                AlbumId = 4

            };

            for (int i = 0; i < 3; i++)
            {
                dbContext.Tracks.Add(track);
               
            }
                dbContext.SaveChanges();

            var result = dbContext.Tracks.CountAsync().Result;

            Assert.AreNotEqual(result, true);
            Assert.AreEqual(result, 1);
            Assert.That(result, Is.Not.Null);
            
        }

        [Test]
        public void TestTrackDelete()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("trackDelete").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new TrackService(dbContext);

            var track = new Track
            {
                Id = 1,
                Name = "Joni",
                Duration = "4:44",
                AlbumId = 4

            };


            dbContext.Tracks.Add(track);
            dbContext.SaveChanges();

            var result = service.Delete(track.Id);

            Assert.AreNotEqual(result, true);
            Assert.AreEqual(service.TrackExist(track.Id), false);
            Assert.AreEqual(result, false);
            Assert.That(track.Id, Is.Not.Null);

        }

        [Test]
        public void TestTrackEdit()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("trackEditCorrect").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new TrackService(dbContext);

            var track = new Track
            {
                Id = 1,
                Name = "Joni",
                Duration = "4:44",
                AlbumId = 4

            };

            dbContext.Tracks.Add(track);
            dbContext.SaveChanges();

            var result = service.Edit(track.Id, track.Name, track.Duration, track.AlbumId);

            Assert.AreNotEqual(track, result);
            Assert.AreEqual("Joni", track.Name);
            Assert.AreNotEqual("Joki", track.Name);
            Assert.That(result, Is.Not.Null);
            Assert.That(track.Id, Is.Not.Null);
            Assert.AreEqual(result, true);
        }

        [Test]
        public void TestTracksDetails()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("trackDetails").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new TrackService(dbContext);

            var track = new Track
            {
                Id = 1,
                Name = "Joni",
                Duration = "4:44",
                AlbumId = 4

            };

            dbContext.Tracks.Add(track);
            dbContext.SaveChanges();

            var result = service.TrackDetails(track.Id);

            Assert.That(result.Result.Id, Is.Not.Null);
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual("Joni", result.Result.Name);
            Assert.AreNotEqual(2000, result.Result.Name);
            Assert.AreEqual("4:44", result.Result.Duration);
            Assert.AreNotEqual(8, result.Result.AlbumId);
            Assert.AreEqual(track.AlbumId, result.Result.AlbumId);
        }

        [Test]
        public void TestTracks()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("tracksIndex").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new TrackService(dbContext);

            var track = new Track
            {
                Id = 1,
                Name = "Joni",
                Duration = "4:44",
                AlbumId = 4

            };

            dbContext.Tracks.Add(track);
            dbContext.SaveChanges();

            var result = service.Index("aaa", "Joni", 5, 5);

            Assert.That(result, Is.Not.Null);
            Assert.That(track.Id, Is.Not.Null);
            Assert.AreEqual("aaa", result.Result.UserId);
            Assert.AreNotEqual("bbbaaa", result.Result.UserId);

            Assert.AreNotEqual("aaaa", result.Result.AlbumId);
            Assert.AreNotEqual("aaa", result.Result.SearchTerm);
            Assert.AreEqual("Joni", result.Result.SearchTerm);
            Assert.AreEqual(5, result.Result.PageNum);
            Assert.AreNotEqual("int", result.Result.PageNum);
            Assert.AreEqual(5, result.Result.PageSize);
            Assert.AreNotEqual("aaa", result.Result.PageNum);
        }
    }
}
