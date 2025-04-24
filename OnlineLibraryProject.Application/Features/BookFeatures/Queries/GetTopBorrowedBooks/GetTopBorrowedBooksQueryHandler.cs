using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Book;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookFeatures.Queries.GetTopBorrowedBooks;

public class GetTopBorrowedBooksQueryHandler : BookHandler, IRequestHandler<GetTopBorrowedBooksQuery, ListDataResponse<TopBorrowedBooksDto>>
{
    public GetTopBorrowedBooksQueryHandler(IBookService bookService) : base(bookService)
    {
    }

    public async Task<ListDataResponse<TopBorrowedBooksDto>> Handle(GetTopBorrowedBooksQuery request, CancellationToken cancellationToken)
    {
        return await _bookService.GetTopBorrowedBooks();
    }
}
