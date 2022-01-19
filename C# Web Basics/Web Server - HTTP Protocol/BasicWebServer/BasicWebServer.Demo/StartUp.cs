using BasicWebServer.Server;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;
using System;

namespace BasicWebServer.Demo
{
    public class StartUp
    {
        public static void Main()
            => new HttpServer(routes => routes
            .MapGet("/", new TextResponse("Hello from the server!"))
            //.MapGet("/HTML", new HtmlResponse("<h1>HTML response</h1>"))
            .MapGet("/Redirect", new RedirectResponse("http://softuni.org/"))
            .MapGet("/HTML", new HtmlResponse(StartUp.HtmlForm))
            .MapPost("/HTML", new TextResponse("", StartUp.AddFormDataAction)))
            .Start();

        //var server = new HttpServer("127.0.0.1", 8080);
        //server.Start();

        private const string HtmlForm = 
            @"<form action='/HTML' method='POST'>
            Name: <input type ='text' name ='Name'/>
            Age: <input type ='number' name= 'Age'/>
            <input type = 'submit' value = 'Save'/>
            </form>";

        private static void AddFormDataAction(Request request, Response response)
        {
            response.Body = "";

            foreach (var (key, value) in request.Form)
            {
                response.Body += $"{key} - {value}";
                response.Body += Environment.NewLine;
            }
        }
    }
}