using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookRating;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookRatingFeatures.Queries.GetBookRatings;

public class GetBookRatingsQueryHandler : BookRatingHandler, IRequestHandler<GetBookRatingsQuery, DataResponse<BookRatingsDto>>
{
    public GetBookRatingsQueryHandler(IBookRatingService bookRatingService) : base(bookRatingService)
    {
    }

    public async Task<DataResponse<BookRatingsDto>> Handle(GetBookRatingsQuery request, CancellationToken cancellationToken)
    {
        return await _bookRatingService.GetBookRatings(request.BookId);
    }
}
