using Microsoft.EntityFrameworkCore;
using MusicSpot.Data;
using MusicSpot.Data.Models;
using MusicSpot.Services.Books;
using NUnit.Framework;

namespace MusicSpot.Test
{
    public class BookServiceTest
    {
        [Test]
        public void BookCreateTest()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("BookCreateCorrect").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new BookService(dbContext);

            var book = new Book
            {
                Title = "It",
                Genre = "Horror",
                ImageUrl = "aaa",
                Description = "some description",
                UserId = "aaa"
            };

            var result = service.Create(book.Title, book.Genre, book.ImageUrl, book.Description, book.UserId);

            Assert.That(result, Is.Not.Null);
            Assert.AreEqual("It", book.Title);
            Assert.That(book.Id, Is.Not.Null);

        }

        [Test]
        public void TestAllBooks()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("returnBooksNotNull").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new BookService(dbContext);

            var result = service.AllBooks("aaa", "horror", 5, 5);
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual("aaa", result.Result.UserId);
            Assert.AreEqual("horror", result.Result.SearchTerm);
            Assert.AreNotEqual("sport", result.Result.SearchTerm);
            Assert.AreNotEqual(6, result.Result.PageNum);
            Assert.AreNotEqual(7, result.Result.PageSize);

            


        }

        [Test]
        public void TestCreateBooksCount()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("createBooksReturnCount").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new BookService(dbContext);

            var book = new Book
            {
                Title = "It",
                Genre = "Horror",
                ImageUrl = "aaa",
                Description = "some description",
                UserId = "aaa"
            };

            for (int i = 1; i < 5; i++)
            {
                service.Create(book.Title, book.Genre, book.ImageUrl, book.Description, book.UserId);

                dbContext.SaveChanges();
            }

            dbContext.SaveChanges();

            int result = dbContext.Books.CountAsync().Result;

            Assert.AreEqual(4, result);
            Assert.That(result, Is.Not.Null);
            Assert.That(book.Id, Is.Not.Null);

            dbContext.Remove(book);

        }

        [Test]
        public void TestBooksList()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("booksListCount").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new BookService(dbContext);

            var book = new Book
            {
                Title = "It",
                Genre = "Horror",
                ImageUrl = "aaa",
                Description = "some description",
                UserId = "aaa"
            };

            dbContext.Books.Add(book);
            dbContext.SaveChanges();

            var result = service.BooksList(book.UserId);

            Assert.That(result, Is.Not.Null);
            Assert.AreEqual(dbContext.Books.CountAsync().Result, 1);
            Assert.That(book.Id, Is.Not.Null);

        }

        [Test]
        public void TestBookExist()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("bookExist").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new BookService(dbContext);

            var book = new Book
            {
                Id = 1,
                Title = "It",
                Genre = "Horror",
                ImageUrl = "aaa",
                Description = "some description",
                UserId = "aaa"
            };

            dbContext.Books.Add(book);
            dbContext.SaveChanges();

            var result = service.BookExist(1);

            Assert.AreEqual(result, true);
            Assert.AreNotEqual(result, false);
            Assert.That(book.Id, Is.Not.Null);
        }

        [Test]
        public void TestBookDelete()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("bookDelete").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new BookService(dbContext);

            var book = new Book
            {
                Id = 1,
                Title = "It",
                Genre = "Horror",
                ImageUrl = "aaa",
                Description = "some description",
                UserId = "aaa"
            };

            dbContext.Books.Add(book);
            dbContext.SaveChanges();

            var result = service.Delete(1);

            Assert.AreEqual(result, true);
            Assert.AreEqual(service.BookExist(1), false);
            Assert.AreNotEqual(result, false);
            Assert.That(book.Id, Is.Not.Null);
        }

        [Test]
        public void TestBookEdit()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("bookEditCorrect").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new BookService(dbContext);

            var book = new Book
            {
                Id = 1,
                Title = "It",
                Genre = "Horror",
                ImageUrl = "aaa",
                Description = "some description",
                UserId = "aaa"
            };

            dbContext.Books.Add(book);
            dbContext.SaveChanges();

            var result = service.Edit(book.Id, book.Title, book.Genre, book.ImageUrl, book.Description);

            Assert.AreNotEqual(book, result);
            Assert.AreEqual("It", book.Title);
            Assert.That(result, Is.Not.Null);
            Assert.That(book.Id, Is.Not.Null);
            Assert.AreEqual(result, true);
        }

        [Test]
        public void TestBookDetails()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("bookDetails").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new BookService(dbContext);

            var book = new Book
            {
                Id = 1,
                Title = "It",
                Genre = "Horror",
                ImageUrl = "aaa",
                Description = "some description",
                UserId = "aaa"
            };

            dbContext.Books.Add(book);
            dbContext.SaveChanges();

            var result = service.BooksDetails(book.Id);

            Assert.That(book.Id, Is.Not.Null);
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual("It", book.Title);
            Assert.AreEqual("Horror", book.Genre);
            Assert.AreEqual("some description", book.Description);
            Assert.AreNotEqual(8, book.Id);
        }

        [Test]
        public void TestBookNotExit()
        {
            var options = new DbContextOptionsBuilder<MusicSpotDbContext>().UseInMemoryDatabase("bookNotExist").Options;
            var dbContext = new MusicSpotDbContext(options);
            var service = new BookService(dbContext);

            var book = new Book
            {
                Id = 1,
                Title = "It",
                Genre = "Horror",
                ImageUrl = "aaa",
                Description = "some description",
                UserId = "aaa"
            };

            dbContext.Books.Add(book);
            dbContext.SaveChanges();

            var result = service.BooksDetails(book.Id);

            Assert.That(book.Id, Is.Not.Null);
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual(result.Result.Genre, book.Genre);
            Assert.AreEqual(result.Result.Title, book.Title);
            Assert.AreEqual(result.Result.Id, book.Id);
            Assert.AreEqual(result.Result.ImageUrl, book.ImageUrl);
            Assert.AreNotEqual(result.Result.Description, 2000);

        }
    }
}
