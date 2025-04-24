using OnlineLibraryProject.Application.Features.BookRatingFeatures.Command.CreateBookRating;
using OnlineLibraryProject.Application.Features.BookRatingFeatures.Command.UpdateBookRating;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookRating;
using OnlineLibraryProject.Domain.Dtos.Responses;
using OnlineLibraryProject.Domain.Entities;

namespace OnlineLibraryProject.Application.Services;

public interface IBookRatingService : IGenericService<BookRating, UserRatingDto, BookRatingDto, CreateBookRatingCommand>, IUpdateable<UpdateBookRatingCommand>
{
    Task<DataResponse<BookRatingsDto>> GetBookRatings(string bookId);
    Task<DataResponse<UserRatingsDto>> GetBookRatingsByUser(string userId);
}