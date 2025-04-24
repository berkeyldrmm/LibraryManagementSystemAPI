using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.CategoryFeatures.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : CategoryHandler, IRequestHandler<UpdateCategoryCommand, MessageResponse>
{
    public UpdateCategoryCommandHandler(ICategoryService categoryService) : base(categoryService)
    {
    }

    public async Task<MessageResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        return await _categoryService.Update(request);
    }
}
