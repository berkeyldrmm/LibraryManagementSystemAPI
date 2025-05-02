using Microsoft.AspNetCore.Mvc;
using OnlineLibraryProject.Application.Features.CategoryFeatures.Commands.CreateCategory;
using OnlineLibraryProject.Application.Features.CategoryFeatures.Commands.UpdateCategory;
using OnlineLibraryProject.Application.Features.CategoryFeatures.Queries.GetCategoriesByFiltersPaged;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Category;
using OnlineLibraryProject.Domain.Dtos.Requests;
using OnlineLibraryProject.Domain.Dtos.Responses;
using OnlineLibraryProject.Domain.Entities;
using OnlineLibraryProject.Domain.Repositories;
using OnlineLibraryProject.Persistance.Pagination;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Claims;

namespace OnlineLibraryProject.Persistance.Services;

public class CategoryService : GenericService<Category, CategoryListDto, CategoryDto, CreateCategoryCommand, ICategoryRepository>, ICategoryService
{
    public CategoryService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public async Task<PagedListDataResponse<CategoryListDto>> GetAllPaged(PageRequest request)
    {
        return await _repository.GetAll<CategoryListDto>().PagedListResponse(request.PageSize, request.PageNumber);
    }

    public async Task<DataResponse<CategoryDto>> CreateCategory(CreateCategoryCommand dto, CancellationToken cancellationToken)
    {
        Category entity = _mapper.Map<Category>(dto);

        var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!string.IsNullOrEmpty(userId))
        {
            var userIdProp = typeof(Category).GetProperty("UserId", BindingFlags.Public | BindingFlags.Instance);
            if (userIdProp != null && userIdProp.CanWrite)
            {
                var convertedId = Convert.ChangeType(userId, userIdProp.PropertyType);
                userIdProp.SetValue(entity, convertedId);
            }
        }

        _ = await _repository.AddAsync(entity, cancellationToken);
        _ = await _unitOfWork.SaveChangesAsync();

        CategoryDto categoryDto = _mapper.Map<CategoryDto>(entity);

        return new DataResponse<CategoryDto>(categoryDto);
    }

    public Task<PagedListDataResponse<CategoryListDto>> GetPagedByFilters(GetCategoriesByFiltersPagedQuery dto)
    {
        var exp = new List<Expression<Func<Category, bool>>>();

        if(dto.Search != null && dto.Search != string.Empty)
        {
            exp.Add(c => c.Name.ToLower().Contains(dto.Search));
        }

        return _repository.GetByFilters<CategoryListDto>(exp).PagedListResponse(dto.PageSize, dto.PageNumber);
    }

    public async Task<MessageResponse> Update(UpdateCategoryCommand dto)
    {
        Category category = _mapper.Map<Category>(dto);
        _ = _repository.Update(category);
        _ = await _unitOfWork.SaveChangesAsync();

        return new("Category has been updated successfully");
    }
}
