using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Data;
using SMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class CartsController : Controller
    {
        public readonly SMSDbContext data;

        public CartsController(SMSDbContext data)
        {
            this.data = data;
        }

        public HttpResponse Details()
        {
            var user = data.Users
                .Where(x=>x.Id == User.Id)
                .FirstOrDefault();

            var userProduct = data.Products
                .Where(x => x.CartId == user.CartId)
                .Select(x => new DeatilsCartProduct
                {
                    Name = x.Name,
                    Price = x.Price,

                }).ToList();

            return View(userProduct);
        }

        public HttpResponse AddProduct(string productId)
        {
            var product = data.Products
                .Where(p => p.Id == productId)
                .FirstOrDefault();

            var cart = data.Carts
                .Where(c => c.Id == User.Id)
                .FirstOrDefault();

            product.CartId = cart.Id;

            data.SaveChanges();

            return Redirect("/Carts/Details");
        }

        public HttpResponse Buy()
        {
            var cart = this.data.Carts.Where(c => c.Id == User.Id).FirstOrDefault();
            var products = this.data.Products.Where(p => p.CartId == cart.Id).ToList();

            foreach (var item in products)
            {
                item.CartId = null;
            }

            this.data.SaveChanges();
            ;
            return Redirect("/");
        }
    }
}
