using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookRating;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookFeatures.Queries.GetTopRatingBooks;

public class GetTopRatingBooksQueryHandler : BookHandler, IRequestHandler<GetTopRatingBooksQuery, ListDataResponse<TopRatingBooksDto>>
{
    public GetTopRatingBooksQueryHandler(IBookService bookService) : base(bookService)
    {
    }

    public Task<ListDataResponse<TopRatingBooksDto>> Handle(GetTopRatingBooksQuery request, CancellationToken cancellationToken)
    {
        return _bookService.GetTopRatingBooks();
    }
}
