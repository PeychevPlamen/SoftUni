using Microsoft.EntityFrameworkCore;
using MusicSpot.Data;
using MusicSpot.Data.Models;
using MusicSpot.Models.Books;

namespace MusicSpot.Services.Books
{
    public class BookService : IBookService
    {
        private readonly MusicSpotDbContext _context;

        public BookService(MusicSpotDbContext context)
        {
            _context = context;
        }

        public async Task<AllBooksViewModel> AllBooks(string userId, string searchTerm, int p, int s)
        {
            var currBooks = await _context.Books.Where(a => a.UserId == userId).ToListAsync();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                currBooks = currBooks.Where(a => a.Title.ToLower().Contains(searchTerm.ToLower())).ToList();
            }

            var result = new AllBooksViewModel
            {
                Books = currBooks
                              .OrderBy(x => x.Title)
                              .Skip(p * s - s)
                              .Take(s)
                              .ToList(),
                SearchTerm = searchTerm,
                PageNum = p,
                PageSize = s,
                TotalRec = currBooks.Count(),
                UserId = userId
            };

            return result;
        }

        public bool BookExist(int bookId)
        {
            throw new NotImplementedException();
        }

        public async Task<DetailsBooksFormModel> BooksDetails(int? bookId)
        {
            var book = await _context.Books
                          .FirstOrDefaultAsync(m => m.Id == bookId);

            var result = new DetailsBooksFormModel
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                ImageUrl = book.ImageUrl,
                Description = book.Description
            };

            return result;

        }

        public Task<List<Book>> BooksList(string userId)
        {
            throw new NotImplementedException();
        }

        public int Create(string title, string genre, string imageUrl, string description, string userId)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int bookId)
        {
            throw new NotImplementedException();
        }

        public bool Edit(int bookId, string title, string genre, string imageUrl, string description)
        {
            throw new NotImplementedException();
        }
    }
}
