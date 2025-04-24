using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Category;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.CategoryFeatures.Queries.GetCategoryById;

public class GetCategoryByIdQueryHandler : CategoryHandler, IRequestHandler<GetCategoryByIdQuery, DataResponse<CategoryDto>>
{
    public GetCategoryByIdQueryHandler(ICategoryService categoryService) : base(categoryService)
    {
    }

    public async Task<DataResponse<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        return await _categoryService.GetByIdAsync(request.Id);
    }
}
