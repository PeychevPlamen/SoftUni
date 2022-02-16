using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Services;
using CarShop.ViewModels;
using CarShop.ViewModels.Issues;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IUserService users;
        private readonly IValidator validator;
        private readonly ApplicationDbContext data;

        public IssuesController(IUserService users, IValidator validator, ApplicationDbContext data)
        {
            this.users = users;
            this.validator = validator;
            this.data = data;
        }

        [Authorize]
        public HttpResponse CarIssues(string carId)
        {
            if (!UserCanAccessCar(carId))
            {
                return Unauthorized();
            }

            var carIssues = data
                .Cars
                .Where(i => i.Id == carId)
                .Select(c => new CarIssuesViewModel
                {
                    Id = c.Id,
                    Model = c.Model,
                    Year = c.Year,
                    UserIsMechanic = users.IsMechanic(User.Id),
                    Issues = c.Issues.Select(i => new IssueListingViewModel
                    {
                        Id = i.Id,
                        Description = i.Description,
                        IsFixed = i.IsFixed,
                        IsFixedInformation = i.IsFixed ? "Yes" : "Not Yet"
                    })
                })
                .FirstOrDefault();

            if (carIssues == null)
            {
                return NotFound();
            }

            return View(carIssues);
        }

        [Authorize]
        public HttpResponse Add(string carId)
            => View(new AddIssueViewModel
            {
                CarId = carId
            });

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddIssueFormModel model)
        {
            if (!UserCanAccessCar(model.CarId))
            {
                return Unauthorized();
            }

            var modelErrors = validator.ValidateIssue(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var issue = new Issue
            {
                Description = model.Description,
                CarId = model.CarId,
            };

            data.Issues.Add(issue);
            data.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={model.CarId}");
        }
        
        [Authorize]
        public HttpResponse Fix(string issueId, string carId)
        {
            var userIsMechanic = users.IsMechanic(User.Id);

            if (!userIsMechanic)
            {
                return Unauthorized();
            }

            var issue = data.Issues.Find(issueId);

            issue.IsFixed = true;

            data.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }

        [Authorize]
        public HttpResponse Delete(string issueId, string carId)
        {
            if (!UserCanAccessCar(carId))
            {
                return Unauthorized();
            }

            var issue = data.Issues.Find(issueId);

            data.Issues.Remove(issue);

            data.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }


        private bool UserCanAccessCar(string carId)
        {
            var userIsMechanic = users.IsMechanic(User.Id);

            if (!userIsMechanic)
            {
                var userOwnsCar = users.OwnsCar(User.Id, carId);

                if (!userOwnsCar)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
