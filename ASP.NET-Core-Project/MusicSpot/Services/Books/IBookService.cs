using MusicSpot.Data.Models;
using MusicSpot.Models.Books;

namespace MusicSpot.Services.Books
{
    public interface IBookService
    {
        Task<AllBooksViewModel> AllBooks(string userId, string searchTerm, int p, int s);

        Task<List<Book>> BooksList(string userId);

        Task<DetailsBooksFormModel> BooksDetails(int? bookId);

        int Create(
           string title,
           string genre,
           string imageUrl,
           string description,
           string userId);

        bool Edit(
           int bookId,
           string title,
           string genre,
           string imageUrl,
           string description);

        bool Delete(int bookId);

        bool BookExist(int bookId);
    }
}
