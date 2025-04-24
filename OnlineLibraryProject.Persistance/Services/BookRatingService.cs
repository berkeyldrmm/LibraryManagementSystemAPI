using Microsoft.EntityFrameworkCore;
using OnlineLibraryProject.Application.Features.BookRatingFeatures.Command.CreateBookRating;
using OnlineLibraryProject.Application.Features.BookRatingFeatures.Command.UpdateBookRating;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookRating;
using OnlineLibraryProject.Domain.Dtos.Responses;
using OnlineLibraryProject.Domain.Entities;
using OnlineLibraryProject.Domain.Repositories;
using System.Security.Claims;

namespace OnlineLibraryProject.Persistance.Services;

public class BookRatingService : GenericService<BookRating, UserRatingDto, BookRatingDto, CreateBookRatingCommand, IBookRatingRepository>, IBookRatingService
{
    public BookRatingService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public async Task<DataResponse<BookRatingsDto>> GetBookRatings(string bookId)
    {
        return new DataResponse<BookRatingsDto>(await _repository.GetBookRatings(bookId).FirstOrDefaultAsync());
    }

    public async Task<DataResponse<UserRatingsDto>> GetBookRatingsByUser(string userId)
    {
        return new DataResponse<UserRatingsDto>(await _repository.GetBookRatingsByUser(userId).FirstOrDefaultAsync());
    }

    public async Task<MessageResponse> Update(UpdateBookRatingCommand dto)
    {
        BookRating bookRating = await _repository.GetByIdAsync(dto.Id);

        if (bookRating.UserId == _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value)
        {
            bookRating.Star = dto.Rating;

            _ = _repository.Update(bookRating);
            _ = await _unitOfWork.SaveChangesAsync();

            return new("User's book rating has been updated successfully");
        }

        throw new Exception("You do not have a permission to update this rating.");
    }
}
