
using AutoMapper;
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
        public void Test1()
        {
            Assert.Pass();
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