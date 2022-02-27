using FootballManager.Data;
using FootballManager.Data.Models;
using FootballManager.Services;
using FootballManager.ViewModels.Players;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
        private readonly FootballManagerDbContext data;
        private readonly IValidator validator;

        public PlayersController(FootballManagerDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse All()
        {
            var all = data.Players.Select(x => new AllPlayersViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                ImageUrl = x.ImageUrl,
                Position = x.Position,
                Speed = x.Speed,
                Endurance = x.Endurance,
                Description = x.Description

            }).ToList();

            return View(all);
        }

        [Authorize]
        public HttpResponse Collection()
        {
            var myPlayers = data.UserPlayers.Where(x => x.UserId == User.Id).Select(x => new CollectionPlayersViewModel
            {
                Id = x.Player.Id.ToString(),
                FullName = x.Player.FullName,
                ImageUrl = x.Player.ImageUrl,
                Position = x.Player.Position,
                Speed = x.Player.Speed,
                Endurance = x.Player.Endurance,
                Description = x.Player.Description,

            }).ToList();

            return View(myPlayers);

        }

        [Authorize]
        public HttpResponse Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddPlayerFormModel model)
        {
            var modelErrors = validator.ValidatePlayer(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var player = new Player
            {
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                Position = model.Position,
                Speed = model.Speed,
                Endurance = model.Endurance,
                Description = model.Description,
            };

            data.Players.Add(player);
            data.SaveChanges();

            var userPlayer = new UserPlayer
            {
                UserId = User.Id,
                PlayerId = player.Id,
            };

            data.UserPlayers.Add(userPlayer);
            data.SaveChanges();

            return Redirect("/Players/All");
        }

        [Authorize]
        public HttpResponse AddToCollection(int playerId)
        {
            var player = data.Players.Where(p => p.Id == playerId).FirstOrDefault();

            if (!data.Players.Where(p => p.Id == playerId).Any())
            {
                return Error("Player doesn't exist.");
            }

            if (data.UserPlayers.Any(x => x.PlayerId == playerId && x.UserId == User.Id))
            {
                return Redirect("/Players/All");
            }


            var userPlayer = new UserPlayer
            {
                PlayerId = playerId,
                UserId = User.Id,
            };

            data.UserPlayers.Add(userPlayer);
            data.SaveChanges();

            return Redirect("/Players/All");
        }

        [Authorize]
        public HttpResponse RemoveFromCollection(int playerId)
        {
            var player = data.Players.Where(p => p.Id == playerId).FirstOrDefault();

            if (player == null || !this.data.UserPlayers.Any(x => x.PlayerId == playerId && x.UserId == User.Id))
            {
                return BadRequest();
            }

            data.Players.Remove(player);

            data.SaveChanges();

            return Redirect("/Players/Collection");
        }
    }
}
