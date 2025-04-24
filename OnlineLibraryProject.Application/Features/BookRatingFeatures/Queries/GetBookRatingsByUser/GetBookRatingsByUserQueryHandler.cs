using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookRating;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookRatingFeatures.Queries.GetBookRatingsByUser;

public class GetBookRatingsByUserQueryHandler : BookRatingHandler, IRequestHandler<GetBookRatingsByUserQuery, DataResponse<UserRatingsDto>>
{
    public GetBookRatingsByUserQueryHandler(IBookRatingService bookRatingService) : base(bookRatingService)
    {
    }

    public async Task<DataResponse<UserRatingsDto>> Handle(GetBookRatingsByUserQuery request, CancellationToken cancellationToken)
    {
        return await _bookRatingService.GetBookRatingsByUser(request.UserId);
    }
}
