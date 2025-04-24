using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Category;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.CategoryFeatures.Queries.GetAllCategoriesPaged;

public class GetAllCategoriesPagedQueryHandler : CategoryHandler, IRequestHandler<GetAllCategoriesPagedQuery, PagedListDataResponse<CategoryListDto>>
{
    public GetAllCategoriesPagedQueryHandler(ICategoryService categoryService) : base(categoryService)
    {
    }

    public async Task<PagedListDataResponse<CategoryListDto>> Handle(GetAllCategoriesPagedQuery request, CancellationToken cancellationToken)
    {
        return await _categoryService.GetAllPaged(request);
    }
}
