using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Book;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookFeatures.Queries.GetBookById;

public class GetBookByIdQueryHandler : BookHandler, IRequestHandler<GetBookByIdQuery, DataResponse<BookDto>>
{
    public GetBookByIdQueryHandler(IBookService bookService) : base(bookService)
    {
    }

    public async Task<DataResponse<BookDto>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        return await _bookService.GetByIdAsync(request.Id);
    }
}
