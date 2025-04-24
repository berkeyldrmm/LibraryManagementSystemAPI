using MediatR;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Category;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.CategoryFeatures.Commands.CreateCategory;

public record CreateCategoryCommand(
    string Name) : IRequest<DataResponse<CategoryDto>>;
