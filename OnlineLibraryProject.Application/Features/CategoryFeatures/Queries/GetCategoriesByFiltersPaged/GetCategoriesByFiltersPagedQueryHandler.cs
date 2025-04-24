using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Category;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.CategoryFeatures.Queries.GetCategoriesByFiltersPaged;

public class GetCategoriesByFiltersPagedQueryHandler : CategoryHandler, IRequestHandler<GetCategoriesByFiltersPagedQuery, PagedListDataResponse<CategoryListDto>>
{
    public GetCategoriesByFiltersPagedQueryHandler(ICategoryService categoryService) : base(categoryService)
    {
    }

    public async Task<PagedListDataResponse<CategoryListDto>> Handle(GetCategoriesByFiltersPagedQuery request, CancellationToken cancellationToken)
    {
        return await _categoryService.GetPagedByFilters(request);
    }
}
