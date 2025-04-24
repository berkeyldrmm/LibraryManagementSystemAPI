using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.CategoryFeatures.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : CategoryHandler, IRequestHandler<DeleteCategoryCommand, MessageResponse>
{
    public DeleteCategoryCommandHandler(ICategoryService categoryService) : base(categoryService)
    {
    }

    public async Task<MessageResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        return await _categoryService.Delete(request.Id, cancellationToken);
    }
}
