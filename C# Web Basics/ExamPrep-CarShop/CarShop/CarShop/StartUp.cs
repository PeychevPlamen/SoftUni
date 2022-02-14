namespace CarShop
{
    using BasicWebServer.Server;
    using BasicWebServer.Server.Routing;
    using CarShop.Data;
    using System.Threading.Tasks;

    public class Startup
    {
        public static async Task Main()
        {
            var server = new HttpServer(routes => routes
               .MapControllers()
               .MapStaticFiles());


            server.ServiceCollection
                .Add<ApplicationDbContext>();
                
            
            await server.Start();
        }
    }
}