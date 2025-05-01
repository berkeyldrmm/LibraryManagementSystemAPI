using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookRating;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookRatingFeatures.Queries.GetBookRatingByUser;

public class GetBookRatingByUserQueryHandler : BookRatingHandler, IRequestHandler<GetBookRatingByUserQuery, DataResponse<UserBookRatingDto>>
{
    public GetBookRatingByUserQueryHandler(IBookRatingService bookRatingService) : base(bookRatingService)
    {
    }

    public async Task<DataResponse<UserBookRatingDto>> Handle(GetBookRatingByUserQuery request, CancellationToken cancellationToken)
    {
        return await _bookRatingService.GetUserBookRating(request.bookId);
    }
}
