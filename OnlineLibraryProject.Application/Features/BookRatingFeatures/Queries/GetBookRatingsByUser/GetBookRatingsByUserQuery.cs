using MediatR;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookRating;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookRatingFeatures.Queries.GetBookRatingsByUser;

public record GetBookRatingsByUserQuery(string UserId) : IRequest<DataResponse<UserRatingsDto>>;