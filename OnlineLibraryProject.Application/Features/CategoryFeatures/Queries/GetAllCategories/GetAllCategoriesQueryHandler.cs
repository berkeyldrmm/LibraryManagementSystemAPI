using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Category;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.CategoryFeatures.Queries.GetAllCategories;

public class GetAllCategoriesQueryHandler : CategoryHandler, IRequestHandler<GetAllCategoriesQuery, ListDataResponse<CategoryListDto>>
{
    public GetAllCategoriesQueryHandler(ICategoryService categoryService) : base(categoryService)
    {
    }

    public async Task<ListDataResponse<CategoryListDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _categoryService.GetList();
    }
}
