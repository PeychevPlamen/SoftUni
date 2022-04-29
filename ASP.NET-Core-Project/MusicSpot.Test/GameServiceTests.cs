using Microsoft.EntityFrameworkCore;
using MusicSpot.Data;
using MusicSpot.Data.Models;
using MusicSpot.Services.Games;
using NUnit.Framework;

namespace MusicSpot.Test
{
    public class GameServiceTests
    {
        [Test]
        public void GameCreateTest()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("GameCreateCorrect").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new GameService(dbContext);

            var game = new Game
            {
                Title = "FIFA",
                Genre = "Sport",
                ImageUrl = "aaa",
                Description = "some description",
                UserId = "aaa"
            };

            var result = service.Create(game.Title, game.Genre, game.ImageUrl, game.Description, game.UserId);

            Assert.That(result, Is.Not.Null);
            Assert.AreEqual("FIFA", game.Title);
            Assert.AreEqual(1, result);
            Assert.That(game.Id, Is.Not.Null);

        }

        [Test]
        public void TestAllGames()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("returnGamesNotNull").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new GameService(dbContext);

            var game = new Game
            {
                Title = "FIFA",
                Genre = "Sport",
                ImageUrl = "aaa",
                Description = "some description",
                UserId = "aaa"
            };

            var result = service.AllGames(game.UserId, "sport", 5, 5);
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("aaa", result.Result.UserId);
            Assert.AreEqual("sport", result.Result.SearchTerm);
            Assert.AreNotEqual(7, result.Result.PageNum);

        }

        [Test]
        public void TestCreateGamesCount()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("createGamesReturnCount").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new GameService(dbContext);

            var game = new Game
            {
                Title = "FIFA",
                Genre = "Sport",
                ImageUrl = "aaa",
                Description = "some description",
                UserId = "aaa"
            };

            for (int i = 1; i < 5; i++)
            {
                service.Create(game.Title, game.Genre, game.ImageUrl, game.Description, game.UserId);

                dbContext.SaveChanges();
            }

            dbContext.SaveChanges();

            int result = dbContext.Games.CountAsync().Result;

            Assert.AreEqual(4, result);
            Assert.That(result, Is.Not.Null);
            Assert.That(game.Id, Is.Not.Null);

            dbContext.Remove(game);

        }


        [Test]
        public void TestGameExist()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("gameExist").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new GameService(dbContext);

            var game = new Game
            {
                Id = 1,
                Title = "FIFA",
                Genre = "Sport",
                ImageUrl = "aaa",
                Description = "some description",
                UserId = "aaa"
            };

            var result = service.GameExist(1);

            Assert.AreEqual(result, false);
            Assert.AreNotEqual(result, true);
            Assert.That(game.Id, Is.Not.Null);
        }

        [Test]
        public void TestGameDelete()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("gameDelete").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new GameService(dbContext);

            var game = new Game
            {
                Id = 1,
                Title = "FIFA",
                Genre = "Sport",
                ImageUrl = "aaa",
                Description = "some description",
                UserId = "aaa"
            };

            dbContext.Games.Add(game);
            dbContext.SaveChanges();

            var result = service.Delete(1);

            Assert.AreEqual(result, true);
            Assert.AreEqual(service.GameExist(1), false);
            Assert.AreNotEqual(result, false);
            Assert.That(game.Id, Is.Not.Null);
        }

        [Test]
        public void TestGameEdit()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("gameEditCorrect").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new GameService(dbContext);

            var game = new Game
            {
                Id = 1,
                Title = "FIFA",
                Genre = "Sport",
                ImageUrl = "aaa",
                Description = "some description",
                UserId = "aaa"
            };

            dbContext.Games.Add(game);
            dbContext.SaveChanges();

            var result = service.Edit(game.Id, game.Title, game.Genre, game.ImageUrl, game.Description);

            Assert.AreNotEqual(game, result);
            Assert.AreEqual("FIFA", game.Title);
            Assert.That(result, Is.Not.Null);
            Assert.That(game.Id, Is.Not.Null);
            Assert.AreEqual(result, true);
        }

        [Test]
        public void TestGameDetails()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("gameDetails").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new GameService(dbContext);

            var game = new Game
            {
                Id = 1,
                Title = "FIFA",
                Genre = "Sport",
                ImageUrl = "aaa",
                Description = "some description",
                UserId = "aaa"
            };

            dbContext.Games.Add(game);
            dbContext.SaveChanges();

            var result = service.GameDetails(1);

            Assert.That(game.Id, Is.Not.Null);
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual("FIFA", game.Title);
            Assert.AreEqual("Sport", game.Genre);
            Assert.AreEqual("some description", game.Description);
            Assert.AreNotEqual(8, game.Id);
        }

        [Test]
        public void TestGameNotExit()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("gameNotExist").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new GameService(dbContext);

            var game = new Game
            {
                Id = 1,
                Title = "FIFA",
                Genre = "Action",
                ImageUrl = "aaa",
                Description = "some description",
                UserId = "aaa"
            };

            dbContext.Games.Add(game);
            dbContext.SaveChanges();

            var result = service.GameDetails(game.Id);

            Assert.That(game.Id, Is.Not.Null);
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual(result.Result.Genre, game.Genre);
            Assert.AreEqual(result.Result.Title, game.Title);
            Assert.AreEqual(result.Result.Id, game.Id);
            Assert.AreEqual(result.Result.ImageUrl, game.ImageUrl);
            Assert.AreNotEqual(result.Result.Description, 2000);

        }
    }
}
