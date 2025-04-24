using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookCategoryFeatures.Command.DeleteBookCategory;

public class DeleteBookCategoryCommandHandler : BookCategoryHandler, IRequestHandler<DeleteBookCategoryCommand, MessageResponse>
{
    public DeleteBookCategoryCommandHandler(IBookCategoryService bookCategoryService) : base(bookCategoryService)
    {
    }

    public async Task<MessageResponse> Handle(DeleteBookCategoryCommand request, CancellationToken cancellationToken)
    {
        return await _bookCategoryService.Delete(request.Id, cancellationToken);
    }
}
