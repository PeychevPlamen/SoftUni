using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Data;
using SMS.Data.Models;
using SMS.Services;
using SMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static SMS.Data.DataConstants;

namespace SMS.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IValidator validator;
        private readonly SMSDbContext data;

        public ProductsController(IValidator validator, SMSDbContext data)
        {
            this.validator = validator;
            this.data = data;
        }

        [Authorize]
        public HttpResponse Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(ProductCreateView model)
        {
            var modelErrors = validator.ValidateProduct(model);

            if (modelErrors.Any())
            {
                return View("/Error", modelErrors);
            }

            model.Id = data.Carts.First().Id;

            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                CartId = model.Id
            };


            data.Products.Add(product);
            data.SaveChanges();

            return Redirect("/");
        }
    }
}
