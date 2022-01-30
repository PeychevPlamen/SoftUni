using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Demo.Controllers
{
    public static class RoutingTableExtensions
    {
        public static IRoutingTable MapGet<TController>(this IRoutingTable routingTable, string path, Func<TController, Response> controllerFunction)
            where TController : Controller
            => routingTable.MapGet(path, request => controllerFunction(CreateController<TController>(request)));

        public static IRoutingTable MapPost<TController>(this IRoutingTable routingTable, string path, Func<TController, Response> cotrollerFunction)
            where TController : Controller
            => routingTable.MapPost(path, request => controllerFunction(CreateController<TController>(request)));

        private static TController CreateCotroller<TController>(Request request)
            => (TController)Activator.CreateInstance(typeof(TController), new[] { request });
    }

}
