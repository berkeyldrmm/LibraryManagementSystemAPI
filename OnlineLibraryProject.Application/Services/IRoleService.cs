using OnlineLibraryProject.Application.Features.RoleFeatures.Commands.CreateRole;
using OnlineLibraryProject.Application.Features.RoleFeatures.Commands.UpdateRole;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Services;

public interface IRoleService
{
    Task<MessageResponse> CreateAsync(CreateRoleCommand request);
    Task<MessageResponse> UpdateAsync(UpdateRoleCommand request);
}
