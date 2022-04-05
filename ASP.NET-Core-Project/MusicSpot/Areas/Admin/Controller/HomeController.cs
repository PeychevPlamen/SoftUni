using Microsoft.AspNetCore.Mvc;
using MusicSpot.Areas.Admin.Controllers;
using MusicSpot.Data;

namespace MusicSpot.Areas.Admin.Controller
{
    public class HomeController : AdminController
    {
        private readonly MusicSpotDbContext _context;

        public HomeController(MusicSpotDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //var artists = _context.Artists.ToList();
            //var users = _context.Users.ToList();
            ////return View(_context.Artists.Select(x=>x.Name).AsQueryable());
            //return View(_context.Users.Select(u => u.UserName).AsQueryable());
            return View();
        }

    }
}
