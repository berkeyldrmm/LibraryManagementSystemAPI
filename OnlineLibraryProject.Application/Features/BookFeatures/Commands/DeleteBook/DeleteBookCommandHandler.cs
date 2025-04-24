using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookFeatures.Commands.DeleteBook;

public class DeleteBookCommandHandler : BookHandler, IRequestHandler<DeleteBookCommand, MessageResponse>
{
    public DeleteBookCommandHandler(IBookService bookService) : base(bookService)
    {
    }

    public async Task<MessageResponse> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        return await _bookService.Delete(request.Id, cancellationToken);
    }
}