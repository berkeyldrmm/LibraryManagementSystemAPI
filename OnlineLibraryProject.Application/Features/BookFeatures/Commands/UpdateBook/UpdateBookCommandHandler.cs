using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookFeatures.Commands.UpdateBook;

public class UpdateBookCommandHandler : BookHandler, IRequestHandler<UpdateBookCommand, MessageResponse>
{
    public UpdateBookCommandHandler(IBookService bookService) : base(bookService)
    {
    }

    public async Task<MessageResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        return await _bookService.Update(request);
    }
}
