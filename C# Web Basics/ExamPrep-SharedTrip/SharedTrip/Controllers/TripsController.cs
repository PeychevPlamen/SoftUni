using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Data;
using SharedTrip.Models;
using SharedTrip.Services;
using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public TripsController(ApplicationDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }


        [Authorize]
        public HttpResponse All()
        {

            var all = data.Trips.Select(x => new TripsListViewModel
            {
                Id = x.Id,
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint,
                DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                Seats = x.Seats
            }).ToList();

            return View(all);
        }

        [Authorize]
        public HttpResponse Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Add(TripAddFormModel model)
        {
            var modelErrors = validator.ValidateTrip(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var trip = new Trip()
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = model.DepartureTime,
                Description = model.Description,
                Seats = model.Seats,
                ImagePath = model.ImagePath
            };

            data.Trips.Add(trip);
            data.SaveChanges();

            return Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            if (!data.Trips.Where(t => t.Id == tripId).Any())
            {
                return Error("Trip doesn't exist.");
            }

            var trip = data.Trips
                .Where(t => t.Id == tripId)
                .Select(t => new TripDetailsViewModel
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH: mm", CultureInfo.InvariantCulture),
                    Seats = t.Seats,
                    Description = t.Description,
                    ImagePath = t.ImagePath
                })
                .FirstOrDefault();

            return View(trip);
        }

        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!data.Trips.Where(t => t.Id == tripId).Any())
            {
                return Error("Trip doesn't exist.");
            }

            var trip = data.Trips.Where(t => t.Id == tripId).FirstOrDefault();

            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = User.Id,
            };

            if (data.UserTrips.Where(x=>x.TripId == tripId && x.UserId == User.Id).Any())
            {
                return Error("This user is already added to this trip");
            }

            data.UserTrips.Add(userTrip);
            data.SaveChanges();

            return Redirect("/");

        }
    }
}
