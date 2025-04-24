using MediatR;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Category;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.CategoryFeatures.Queries.GetCategoryById;

public record GetCategoryByIdQuery(string Id) : IRequest<DataResponse<CategoryDto>>;