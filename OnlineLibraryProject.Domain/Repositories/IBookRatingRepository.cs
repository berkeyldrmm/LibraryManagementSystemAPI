using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookRating;
using OnlineLibraryProject.Domain.Entities;

namespace OnlineLibraryProject.Domain.Repositories;

public interface IBookRatingRepository : IGenericRepository<BookRating>
{
    IQueryable<BookRatingsDto> GetBookRatings(string bookId);
    IQueryable<UserBookRatingDto> GetUserBookRating(string bookId);
    IQueryable<UserRatingsDto> GetBookRatingsByUser(string userId);
    bool Any(string bookId);
}
