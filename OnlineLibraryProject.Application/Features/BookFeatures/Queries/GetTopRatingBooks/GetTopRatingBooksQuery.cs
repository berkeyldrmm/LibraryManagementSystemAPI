using MediatR;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookRating;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookFeatures.Queries.GetTopRatingBooks;

public record GetTopRatingBooksQuery() : IRequest<ListDataResponse<TopRatingBooksDto>>;