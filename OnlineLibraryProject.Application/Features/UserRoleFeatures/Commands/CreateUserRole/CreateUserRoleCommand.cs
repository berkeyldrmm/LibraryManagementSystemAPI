using MediatR;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.UserRoleFeatures.Commands.CreateUserRole;

public sealed record CreateUserRoleCommand(
    string UserId,
    string RoleId): IRequest<MessageResponse>;
