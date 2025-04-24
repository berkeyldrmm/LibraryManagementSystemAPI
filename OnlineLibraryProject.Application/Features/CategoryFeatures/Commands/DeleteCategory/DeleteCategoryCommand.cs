using MediatR;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.CategoryFeatures.Commands.DeleteCategory;

public record DeleteCategoryCommand(string Id) : IRequest<MessageResponse>;