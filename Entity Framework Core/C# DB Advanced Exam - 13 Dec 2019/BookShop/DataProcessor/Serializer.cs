namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context.Authors
                .ToArray()
                .Select(x => new
                {
                    AuthorName = x.FirstName + " " + x.LastName,
                    Books = x.AuthorsBooks
                        .OrderByDescending(x => x.Book.Price)
                        .Select(b => new
                        {
                            BookName = b.Book.Name,
                            BookPrice = b.Book.Price.ToString("f2")
                        })
                        .ToArray()
                })
                .OrderByDescending(x => x.Books.Count())
                .ThenBy(x => x.AuthorName)
                .ToArray();

            return JsonConvert.SerializeObject(authors, Formatting.Indented);
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportOldestBooks[]), new XmlRootAttribute("Books"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter sw = new StringWriter(sb);

            var books = context.Books
                .Where(b => b.PublishedOn < date && b.Genre == Genre.Science)
                .OrderByDescending(b => b.Pages)
                .ThenByDescending(b => b.PublishedOn)
                .ToArray()
                .Select(b => new ExportOldestBooks()
                {
                    Name = b.Name,
                    Date = b.PublishedOn.Date.ToString("d", CultureInfo.InvariantCulture),
                    Pages = b.Pages
                })
                .Take(10)
                .ToArray();

            xmlSerializer.Serialize(sw, books, namespaces);

            return sb.ToString().TrimEnd();

        }
    }
}