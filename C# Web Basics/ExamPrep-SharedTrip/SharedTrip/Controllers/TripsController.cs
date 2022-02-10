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
        public HttpResponse Add(TripAddFormModel trip)
        {
            var modelErrors = validator.ValidateTrip(trip);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var currTrip = new Trip()
            {
                StartPoint = trip.StartPoint,
                EndPoint = trip.EndPoint,
                DepartureTime = trip.DepartureTime,
                Description = trip.Description,
                Seats = trip.Seats,
                ImagePath = trip.ImagePath
            };

            data.Trips.Add(currTrip);
            data.SaveChanges();

            return Redirect("/Trips/All");
        }
    }
}
