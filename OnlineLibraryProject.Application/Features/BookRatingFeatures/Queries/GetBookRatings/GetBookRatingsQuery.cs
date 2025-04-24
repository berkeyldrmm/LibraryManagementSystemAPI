using MediatR;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookRating;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookRatingFeatures.Queries.GetBookRatings;

public record GetBookRatingsQuery(string BookId) : IRequest<DataResponse<BookRatingsDto>>;