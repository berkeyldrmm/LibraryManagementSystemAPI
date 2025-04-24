using MediatR;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Category;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.CategoryFeatures.Queries.GetAllCategories;

public record GetAllCategoriesQuery() : IRequest<ListDataResponse<CategoryListDto>>;