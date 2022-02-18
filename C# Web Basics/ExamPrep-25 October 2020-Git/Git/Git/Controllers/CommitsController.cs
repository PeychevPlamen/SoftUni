using Git.Data;
using Git.Data.Models;
using Git.Services;
using Git.ViewModels.Commits;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public CommitsController(IValidator validator, ApplicationDbContext data)
        {
            this.validator = validator;
            this.data = data;
        }

        [Authorize]
        public HttpResponse Create(string id)
        {
            var repo = data.Repositories
                .Where(r => r.Id == id)
                .Select(r => new CommitToRepoViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                })
                .FirstOrDefault();

            if (repo == null)
            {
                return BadRequest();
            }

            return View(repo);
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreateCommitViewModel model)
        {
            if (!data.Repositories.Any(r => r.Id == model.Id))
            {
                return NotFound();
            }

            var modelErrors = validator.ValidateCommit(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var commit = new Commit
            {
                Description = model.Description,
                RepositoryId = model.Id,
                CreatorId = User.Id
            };

            data.Commits.Add(commit);
            data.SaveChanges();

            return Redirect("/Repositories/All");
        }

        [Authorize]
        public HttpResponse All()
        {
            var commits = data.Commits
                .Where(c => c.CreatorId == User.Id)
                .OrderByDescending(c => c.CreatedOn)
                .Select(c => new AllCommitsViewModel
                {
                    Id = c.Id,
                    Description = c.Description,
                    Repository = c.Repository.Name,
                    CreatedOn = c.CreatedOn.ToLocalTime().ToString("F")
                })
                .ToList();

            return View(commits);
        }

        [Authorize]
        public HttpResponse Delete(string id)
        {
            var commit = data.Commits.Find(id);

            if (commit == null || commit.CreatorId != User.Id)
            {
                return BadRequest();
            }

            data.Commits.Remove(commit);

            data.SaveChanges();

            return Redirect("/Commits/All");
        }
    }
}
