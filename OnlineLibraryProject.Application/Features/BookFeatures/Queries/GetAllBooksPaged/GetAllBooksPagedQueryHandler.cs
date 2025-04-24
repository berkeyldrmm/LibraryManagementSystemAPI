using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Book;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookFeatures.Queries.GetAllBooksPaged;

public class GetAllBooksPagedQueryHandler : BookHandler, IRequestHandler<GetAllBooksPagedQuery, PagedListDataResponse<BookListDto>>
{
    public GetAllBooksPagedQueryHandler(IBookService bookService) : base(bookService)
    {
    }

    public async Task<PagedListDataResponse<BookListDto>> Handle(GetAllBooksPagedQuery request, CancellationToken cancellationToken)
    {
        return await _bookService.GetAllPaged(request);
    }
}
