#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicSpot.Data;
using MusicSpot.Data.Models;
using MusicSpot.Infrastructure.Extensions;
using MusicSpot.Models.Books;
using MusicSpot.Services.Books;

namespace MusicSpot.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _service;

        public BooksController(IBookService service)
        {
            _service = service;
        }

        // GET: Books
        public async Task<IActionResult> Index(string searchTerm, int p = 1, int s = 5)
        {
            var userID = User.Id();

            var model = await _service.AllBooks(userID, searchTerm, p, s);

            return View(model);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _service.BooksDetails(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookFormModel book)
        {
            var userId = User.Id();
            book.UserId = userId;

            if (ModelState.IsValid)
            {
                var currBook = _service.Create(
                    book.Title,
                    book.Genre,
                    book.ImageUrl,
                    book.Description,
                    userId);

                return RedirectToAction(nameof(Index));
            }

            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _service.BooksDetails(id);

            if (book == null)
            {
                return NotFound();
            }

            var result = new Book
            {
                Title = book.Title,
                Genre = book.Genre,
                ImageUrl = book.ImageUrl,
                Description = book.Description
            };

            return View(result);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditBookFormModel book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    _service.Edit(
                        book.Id,
                        book.Title,
                        book.Genre,
                        book.ImageUrl,
                        book.Description
                        );
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _service.BooksDetails(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = _service.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _service.BookExist(id);
        }
    }
}
