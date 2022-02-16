using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Services;
using CarShop.ViewModels;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IValidator validator;
        private readonly IUserService users;
        private readonly ApplicationDbContext data;

        public CarsController(
            IValidator validator,
            IUserService users,
            ApplicationDbContext data)
        {
            this.validator = validator;
            this.users = users;
            this.data = data;
        }

        [Authorize]
        public HttpResponse All()
        {
            var carsQuery = data.Cars.AsQueryable();

            if (users.IsMechanic(User.Id))
            {
                carsQuery = carsQuery.Where(c => c.Issues.Any(i => !i.IsFixed));
            }
            else
            {
                carsQuery = carsQuery.Where(c => c.OwnerId == User.Id);
            }

            var cars = carsQuery
                .Select(c => new AllCarsViewModel
                {
                    Id = c.Id,
                    Model = c.Model,
                    Year = c.Year,
                    Image = c.PictureUrl,
                    PlateNumber = c.PlateNumber,
                    RemainingIssues = c.Issues.Count(i => !i.IsFixed),
                    FixedIssues = c.Issues.Count(i => i.IsFixed)
                })
                .ToList();

            return View(cars);
        }

        [Authorize]
        public HttpResponse Add()
        {
            if (users.IsMechanic(User.Id))
            {
                return Error("Mechanics can't add cars.");
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Add(AddNewCarViewModel model)
        {
            var modelErrors = validator.ValidateCar(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var car = new Car
            {
                Model = model.Model,
                Year = model.Year,
                PictureUrl = model.Image,
                PlateNumber = model.PlateNumber,
                OwnerId = User.Id
            };

            data.Cars.Add(car);

            data.SaveChanges();

            return Redirect("/Cars/All");
        }
    }
}
