using OnlineLibraryProject.Domain.Dtos.EntityDtos.Book;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookRating;
using OnlineLibraryProject.Domain.Entities;

namespace OnlineLibraryProject.Domain.Repositories;

public interface IBookRepository : IGenericRepository<Book>
{
    Task<BookDto> GetOneAsync(string id);
    Task<IEnumerable<TopRatingBooksDto>> GetTopRatingBooks();
    Task<IEnumerable<TopBorrowedBooksDto>> GetTopBorrowedBooks();
}
