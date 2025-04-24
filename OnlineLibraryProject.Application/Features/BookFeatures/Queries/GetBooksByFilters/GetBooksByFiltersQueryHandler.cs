using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Book;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookFeatures.Queries.GetBooksByFilters;

public class GetBooksByFiltersQueryHandler : BookHandler, IRequestHandler<GetBooksByFiltersQuery, ListDataResponse<BookListDto>>
{
    public GetBooksByFiltersQueryHandler(IBookService bookService) : base(bookService)
    {
    }

    public async Task<ListDataResponse<BookListDto>> Handle(GetBooksByFiltersQuery request, CancellationToken cancellationToken)
    {
        return await _bookService.GetByFilters(request);
    }
}
