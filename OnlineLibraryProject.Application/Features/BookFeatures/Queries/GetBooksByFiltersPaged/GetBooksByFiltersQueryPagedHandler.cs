using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Features.BookFeatures.Queries.GetPagedBooks;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Book;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookFeatures.Queries.GetBooksByFilters;

public class GetBooksByFiltersQueryPagedHandler : BookHandler, IRequestHandler<GetBooksByFiltersPagedQuery, PagedListDataResponse<BookListDto>>
{
    public GetBooksByFiltersQueryPagedHandler(IBookService bookService) : base(bookService)
    {
    }

    public async Task<PagedListDataResponse<BookListDto>> Handle(GetBooksByFiltersPagedQuery request, CancellationToken cancellationToken)
    {
        return await _bookService.GetPagedByFilters(request);
    }
}
