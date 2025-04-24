using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Category;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.CategoryFeatures.Commands.CreateCategory;

public class CreateCategoryCommandHandler : CategoryHandler, IRequestHandler<CreateCategoryCommand, DataResponse<CategoryDto>>
{
    public CreateCategoryCommandHandler(ICategoryService categoryService) : base(categoryService)
    {
    }

    public async Task<DataResponse<CategoryDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        return await _categoryService.CreateCategory(request, cancellationToken);
    }
}
