using Microsoft.AspNetCore.Mvc;
using MusicSpot.Areas.Admin.Controllers;

namespace MusicSpot.Areas.Admin.Controller
{
    public class HomeController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
