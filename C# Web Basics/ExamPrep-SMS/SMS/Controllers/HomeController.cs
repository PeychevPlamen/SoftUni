namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Data;
    using SMS.ViewModels;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly SMSDbContext data;

        public HomeController(SMSDbContext data)
        {
            this.data = data;
        }

        public HttpResponse Index()
        {
            if (User.IsAuthenticated)
            {
                var user = data.Users.Where(u => u.Id == User.Id).FirstOrDefault();

                var products = data.Products.Select(p => new ProductHomeView
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                }).ToList();

                var model = new AllProductsViewHome
                {
                    Username = user.Username,
                    Products = products,
                };

                return View(model, "IndexLoggedIn");
            }
            return this.View("Index");
        }
    }
}