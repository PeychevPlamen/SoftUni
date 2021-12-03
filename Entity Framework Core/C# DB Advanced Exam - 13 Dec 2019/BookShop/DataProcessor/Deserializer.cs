namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Books");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportBooksDto[]), xmlRoot);

            using StringReader sr = new StringReader(xmlString);

            ImportBooksDto[] BooksDtos = (ImportBooksDto[])xmlSerializer.Deserialize(sr);

            var books = new List<Book>();

            foreach (var book in BooksDtos)
            {
                if (!IsValid(book))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var publishedOnDate = DateTime.ParseExact(book.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                var currBook = new Book()
                {
                    Name = book.Name,
                    Genre = Enum.Parse<Genre>(book.Genre),
                    Price = book.Price,
                    Pages = book.Pages,
                    PublishedOn = publishedOnDate
                };

                books.Add(currBook);

                sb.AppendLine(String.Format(SuccessfullyImportedBook, book.Name, book.Price));
            }

            context.Books.AddRange(books);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportAuthorsDto[] authorsDto = JsonConvert.DeserializeObject<ImportAuthorsDto[]>(jsonString);

            var authors = new List<Author>();

            foreach (var author in authorsDto)
            {
                if (!IsValid(author))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //check if email already exists

                if (authors.Any(a => a.Email == author.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var currAuthor = new Author()
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    Phone = author.Phone,
                    Email = author.Email
                };

                foreach (var book in author.Books)
                {
                    var bookToImport = context.Books.Find(book.Id);

                    if (bookToImport == null)
                    {
                        continue;
                    }

                    currAuthor.AuthorsBooks.Add(new AuthorBook()
                    {
                        Book = bookToImport,
                        Author = currAuthor
                    });

                }
                if (currAuthor.AuthorsBooks.Count() == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                authors.Add(currAuthor);
                sb.AppendLine(String.Format(SuccessfullyImportedAuthor, (currAuthor.FirstName + " " + currAuthor.LastName), currAuthor.AuthorsBooks.Count()));
            }

            context.Authors.AddRange(authors);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}