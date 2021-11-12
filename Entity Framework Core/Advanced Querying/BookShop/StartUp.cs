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
            DbInitializer.ResetDatabase(db);

            // string command = Console.ReadLine();
            // string result = GetBooksByAgeRestriction(db, command); // 2. Age Restriction

            // string result = GetGoldenBooks(db); // 3. Golden Books

            // string result = GetBooksByPrice(db); // 4. Books by Price

            // int yearInput = int.Parse(Console.ReadLine());
            // string result = GetBooksNotReleasedIn(db, yearInput);  // 5. Not Released In

            // var input = Console.ReadLine();
            // string result = GetBooksByCategory(db, input);  // 6. Book Titles by Category

            //var dateInput = Console.ReadLine();
            //string result = GetBooksReleasedBefore(db, dateInput);   // 7. Released Before Date

            //var input = Console.ReadLine();
            //var result = GetAuthorNamesEndingIn(db, input);  // 8. Author Search

            //var input = Console.ReadLine();
            //var result = GetBookTitlesContaining(db, input);  // 9. Book Search

            //var input = Console.ReadLine();
            //var result = GetBooksByAuthor(db, input);  // 10. Book Search by Author

            //var input = int.Parse(Console.ReadLine());
            //var result = CountBooks(db, input);        // 11. Count Books

            // var result = CountCopiesByAuthor(db); // 12. Total Book Copies

            // var result = GetTotalProfitByCategory(db);  // 13. Profit by Category

            // var result = GetMostRecentBooks(db);   // 14. Most Recent Books

            var result = RemoveBooks(db);

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

        // 5. Not Released In

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        // 6. Book Titles by Category

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var inputCat = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(i => i.ToLower())
                .ToArray();

            var books = context.Books
                .Where(b => b.BookCategories.Any(bc => inputCat.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        // 7. Released Before Date

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            DateTime inputDate = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var books = context.Books
                .Where(b => b.ReleaseDate < inputDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    Title = b.Title,
                    EditionType = b.EditionType,
                    Price = b.Price
                })
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 8. Author Search

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName
                })
                .OrderBy(a => a.FullName)
                .ToArray();

            foreach (var author in authors)
            {
                sb.AppendLine(author.FullName);
            }

            return sb.ToString().TrimEnd();
        }

        // 9. Book Search

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var currInput = input.ToLower();

            var titles = context.Books
                .Where(t => t.Title.ToLower().Contains(currInput))
                .Select(t => t.Title)
                .OrderBy(t => t)
                .ToArray();

            foreach (var title in titles)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        // 10. Book Search by Author

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var currInput = input.ToLower();

            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(currInput))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    Titles = b.Title,
                    FullName = b.Author.FirstName + " " + b.Author.LastName
                });

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Titles} ({book.FullName})");
            }

            return sb.ToString().TrimEnd();
        }

        // 11. Count Books

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToArray()
                .Count();

            return books;
        }

        // 12. Total Book Copies

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Authors
                .Select(a => new
                {
                    Author = a.FirstName + " " + a.LastName,
                    TotalCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.TotalCopies)
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Author} - {book.TotalCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        // 13. Profit by Category

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Categories
                .Select(c => new
                {
                    Category = c.Name,
                    TotalProfit = c.CategoryBooks.Sum(b => b.Book.Copies * b.Book.Price)
                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.Category)
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Category} ${book.TotalProfit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 14. Most Recent Books

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Categories
                 .OrderBy(c => c.Name)
                 .Select(c => new
                 {
                     CategoryName = c.Name,
                     Books = c.CategoryBooks
                     .OrderByDescending(b => b.Book.ReleaseDate)
                     .Take(3)
                     .Select(b => new
                     {
                         BookTitle = b.Book.Title,
                         BookDate = b.Book.ReleaseDate.Value.Year
                     })
                 })
                 .ToArray();

            foreach (var cat in books)
            {
                sb.AppendLine($"--{cat.CategoryName}");

                foreach (var book in cat.Books)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.BookDate})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // 15. Increase Prices

        public static void IncreasePrices(BookShopContext context)
        {
            
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        // 16. Remove Books

        public static int RemoveBooks(BookShopContext context)
        {
            var booksCat = context.BooksCategories
                .Where(b => b.Book.Copies < 4200)
                .ToArray();

            context.BooksCategories.RemoveRange(booksCat);

            context.SaveChanges();

            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            context.Books.RemoveRange(books);

            int count = context.SaveChanges();

            return count;
        }
    }
}
