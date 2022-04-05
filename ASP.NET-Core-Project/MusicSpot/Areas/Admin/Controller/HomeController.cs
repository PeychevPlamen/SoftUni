using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicSpot.Areas.Admin.Controllers;
using MusicSpot.Data;
using MusicSpot.Data.Models;
using MusicSpot.Infrastructure.Extensions;
using MusicSpot.Models.Artists;

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
            
            if (User.IsAdmin())
            {
                var currArtist = await _context.Artists.ToListAsync();

                return View(new AllArtistViewModel
                {
                    Artists = currArtist,
                });
            }

            return View(_context.Artists.AsQueryable());
        }
        
    }
}
