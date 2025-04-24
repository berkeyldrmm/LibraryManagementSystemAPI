using MediatR;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.CategoryFeatures.Commands.UpdateCategory;

public record UpdateCategoryCommand(
    string Id,
    string Name) : IRequest<MessageResponse>;
