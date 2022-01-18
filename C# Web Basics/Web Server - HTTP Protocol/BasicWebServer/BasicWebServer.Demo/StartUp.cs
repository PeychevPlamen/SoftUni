using BasicWebServer.Server;
using BasicWebServer.Server.Responses;
using System;

namespace BasicWebServer.Demo
{
    public class StartUp
    {
        public static void Main()
            => new HttpServer(routes => routes
            .MapGet("/", new TextResponse("Hello from the server!"))
            .MapGet("/HTML", new HtmlResponse("<h1>HTML response</h1>"))
            .MapGet("/Redirect", new RedirectResponse("http://softuni.org/")))
            .Start();
        
            //var server = new HttpServer("127.0.0.1", 8080);
            //server.Start();
        
    }
}