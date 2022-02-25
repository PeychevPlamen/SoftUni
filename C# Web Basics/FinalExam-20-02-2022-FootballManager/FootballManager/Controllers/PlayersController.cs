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
                FullName = x.FullName,
                ImageUrl = x.ImageUrl,
                Position = x.Position,
                Speed = x.Speed,
                Endurance = x.Endurance,
                //PlayerId = x.Id
            }).ToList();

            return View(all);
        }

        [Authorize]
        public HttpResponse Collection()
        {
            var myPlayers = data.Players.Select(x => new CollectionPlayersViewModel
            {
                FullName = x.FullName,
                ImageUrl = x.ImageUrl,
                Position = x.Position,
                Speed = x.Speed,
                Endurance = x.Endurance,
                Description = x.Description,
                
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
                Position = model.Position, //  ?????
                Speed = model.Speed,
                Endurance = model.Endurance,
                Description = model.Description,
            };

            data.Players.Add(player);
            data.SaveChanges();

            return Redirect("/Players/All");
        }

        [Authorize]
        //[HttpPost]
        public HttpResponse AddToCollection(int playerId, string userId)
        {
            if (!data.Players.Where(t => t.Id == playerId).Any())
            {
                return Error("Player doesn't exist.");
            }

            var player = data.Players.Where(t => t.Id == playerId).FirstOrDefault();

            var userPlayer = new UserPlayer
            {
                PlayerId = playerId,
                UserId = User.Id,
            };

            if (data.UserPlayers.Where(x => x.PlayerId == playerId && x.UserId == User.Id).Any())
            {
                return Error("This player is already added to this user");
            }

            data.UserPlayers.Add(userPlayer);
            data.SaveChanges();

            return Redirect("/Players/All");
        }

        [Authorize]
        public HttpResponse RemoveFromCollection(int playerId)
        {
            var player = data.UserPlayers.Find(playerId);

            if (player == null)
            {
                return BadRequest();
            }

            data.UserPlayers.Remove(player);

            data.SaveChanges();

            return Redirect("/Players/Collection");
        }
    }
}
