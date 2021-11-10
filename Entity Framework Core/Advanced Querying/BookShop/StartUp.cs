namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            // DbInitializer.ResetDatabase(db);

            // string command = Console.ReadLine();

            // string result = GetBooksByAgeRestriction(db, command); // 2. Age Restriction

            // string result = GetGoldenBooks(db); // 3. Golden Books

            string result = GetBooksByPrice(db);

            Console.WriteLine(result);
        }

        // 2. Age Restriction

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var allBookTitles = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            foreach (var books in allBookTitles)
            {
                sb.AppendLine(books);
            }

            return sb.ToString().TrimEnd();
        }

        // 3. Golden Books

        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var goldenBooks = context.Books
                .Where(gb => gb.Copies < 5000 && gb.EditionType == EditionType.Gold)
                .OrderBy(gb => gb.BookId)
                .Select(gb => gb.Title)
                .ToArray();
                

            foreach (var book in goldenBooks)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        // 4. Books by Price

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    title = b.Title,
                    price = b.Price
                })
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.title} - ${book.price:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
