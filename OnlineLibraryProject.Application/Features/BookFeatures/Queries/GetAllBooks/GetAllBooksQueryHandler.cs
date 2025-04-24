using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Book;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookFeatures.Queries.GetAllBooks;

public class GetAllBooksQueryHandler : BookHandler, IRequestHandler<GetAllBooksQuery, ListDataResponse<BookListDto>>
{
    public GetAllBooksQueryHandler(IBookService bookService) : base(bookService)
    {
    }

    public async Task<ListDataResponse<BookListDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        return await _bookService.GetList();
    }
}
