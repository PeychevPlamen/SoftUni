using Git.Data;
using Git.Data.Models;
using Git.Services;
using Git.ViewModels.Repositories;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Git.Data.DataConstants;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext data;

        public RepositoriesController(IValidator validator, IPasswordHasher passwordHasher, ApplicationDbContext data)
        {
            this.validator = validator;
            this.data = data;
        }


        public HttpResponse All()
        {
            var repositoriesQuery = data.Repositories.AsQueryable();

            if (User.IsAuthenticated)
            {
                repositoriesQuery = repositoriesQuery.Where(r => r.IsPublic || r.OwnerId == User.Id);
            }
            else
            {
                repositoriesQuery = repositoriesQuery.Where(r => r.IsPublic);
            }

            var repos = repositoriesQuery
                .OrderByDescending(r => r.CreatedOn)
                .Select(r => new AllRepoViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Owner = r.Owner.Username,
                    CreatedOn = r.CreatedOn.ToLocalTime().ToString("F"),
                    CommitsCount = r.Commits.Count()
                })
                .ToList();

            return View(repos);
        }

        [Authorize]
        public HttpResponse Create() => View();

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreateRepoViewModel model)
        {
            var modelErrors = this.validator.ValidateRepository(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var repo = new Repository
            {
                Name = model.Name,
                IsPublic = model.RepositoryType == RepositoryPublicType,
                OwnerId = User.Id
            };

            data.Repositories.Add(repo);

            data.SaveChanges();

            return Redirect("/Repositories/All");
        }
    }
}
