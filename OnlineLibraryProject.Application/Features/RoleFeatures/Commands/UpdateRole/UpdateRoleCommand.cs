using MediatR;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.RoleFeatures.Commands.UpdateRole;

public record UpdateRoleCommand(
    string Id,
    string Name) : IRequest<MessageResponse>;
