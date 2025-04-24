using OnlineLibraryProject.Application.Features.CategoryFeatures.Commands.CreateCategory;
using OnlineLibraryProject.Application.Features.CategoryFeatures.Commands.UpdateCategory;
using OnlineLibraryProject.Application.Features.CategoryFeatures.Queries.GetCategoriesByFiltersPaged;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Category;
using OnlineLibraryProject.Domain.Dtos.Responses;
using OnlineLibraryProject.Domain.Entities;

namespace OnlineLibraryProject.Application.Services
{
    public interface ICategoryService : IGenericService<Category, CategoryListDto, CategoryDto, CreateCategoryCommand>, IUpdateable<UpdateCategoryCommand>, IPaged<CategoryListDto, GetCategoriesByFiltersPagedQuery>
    {
        Task<DataResponse<CategoryDto>> CreateCategory(CreateCategoryCommand dto, CancellationToken cancellationToken);
    }
}
