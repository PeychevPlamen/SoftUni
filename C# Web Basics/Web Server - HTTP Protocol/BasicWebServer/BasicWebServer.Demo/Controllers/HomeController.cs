﻿using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BasicWebServer.Demo.Controllers
{
    public class HomeController : Controller
    {
        private const string HtmlForm =
            @"<form action='/HTML' method='POST'>
            Name: <input type ='text' name ='Name'/>
            Age: <input type ='number' name= 'Age'/>
            <input type = 'submit' value = 'Save'/>
            </form>";

        private const string DownloadForm =
            @"<form action='/Content' method='POST'>
            <input type='submit' value = 'Download Sites Content' />
            </form>";

        private const string FileName = "content.txt";

        public HomeController(Request request)
            : base(request)
        {

        }

        public Response Index() => Text("Hello from the server");
        public Response Redirect() => Redirect("https://");
        public Response Html() => Html(HtmlForm);
        public Response HtmlFormPost()
        {
            string formData = string.Empty;

            foreach (var (key, value) in this.Request.Form)
            {
                formData += $"{key} - {value}";
                formData += Environment.NewLine;
            }

            return Text(formData);
        }

        public Response Content() => Html(DownloadForm);

        public Response DownloadContent()
        {
            DownloadSitesAsTextFile(FileName, new string[] { "https://judge.softuni.org/", "https://softuni.org/" })
                .Wait();

            return File(FileName);
        }

        public Response Cookies()
        {
            if (this.Request.Cookies.Any(c => c.Name != BasicWebServer.Server.HTTP.Session.SessionCookieName))
            {
                var cookieText = new StringBuilder();
                cookieText.AppendLine("<h1>Cookies</h1>");

                cookieText.Append("<table border='1'><tr><th>Name</th><th>Value</th></tr>");

                foreach (var cookie in Request.Cookies)
                {
                    cookieText.Append("<tr>");
                    cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");
                    cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");
                    cookieText.Append("</tr>");
                }

                cookieText.Append("</table>");

                return Html(cookieText.ToString());
            }
            var cookies = new CookieCollection();

            cookies.Add("My-Cookie", "My-Value");
            cookies.Add("My-Second-Cookie", "My-Second-Value");

            return Html("<h1>Cookies set!</h1>", cookies);

        }

        public Response Session()
        {
            string currentDataKey = "CurrentDate";
            var sessionExists = Request.Session.ContainsKey(currentDataKey);

            if (sessionExists)
            {
                var currentDate = Request.Session[currentDataKey];

                return Text($"Stored date: {currentDate}!");
            }

            return Text("Current date stored!");
        }

        private static async Task DownloadSitesAsTextFile(string fileName, string[] urls)
        {
            var downloads = new List<Task<string>>();

            foreach (var url in urls)
            {
                downloads.Add(DownloadWebSiteContent(url));
            }

            var responses = await Task.WhenAll(downloads);

            var responsesString = string.Join(Environment.NewLine + new String('-', 100), responses);

            // await File.WriteAllTextAsync(fileName, responsesString);
        }

        private static async Task<string> DownloadWebSiteContent(string url)
        {
            var httpClient = new HttpClient();
            using (httpClient)
            {
                var response = await httpClient.GetAsync(url);
                var html = await response.Content.ReadAsStringAsync();

                return html.Substring(0, 2000);
            }
        }

    }
}