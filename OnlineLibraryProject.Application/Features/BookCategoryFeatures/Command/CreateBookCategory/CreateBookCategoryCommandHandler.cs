using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookCategoryFeatures.Command.CreateBookCategory;

public class CreateBookCategoryCommandHandler : BookCategoryHandler, IRequestHandler<CreateBookCategoryCommand, MessageResponse>
{
    public CreateBookCategoryCommandHandler(IBookCategoryService bookCategoryService) : base(bookCategoryService)
    {
    }

    public async Task<MessageResponse> Handle(CreateBookCategoryCommand request, CancellationToken cancellationToken)
    {
        return await _bookCategoryService.Create(request, cancellationToken);
    }
}
