using MediatR;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookRating;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookRatingFeatures.Queries.GetBookRatingByUser;

public record GetBookRatingByUserQuery(string bookId) : IRequest<DataResponse<UserBookRatingDto>>;