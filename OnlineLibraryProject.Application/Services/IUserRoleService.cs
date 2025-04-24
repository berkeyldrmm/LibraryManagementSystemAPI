using OnlineLibraryProject.Application.Features.UserRoleFeatures.Commands.CreateUserRole;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Services;

public interface IUserRoleService
{
    Task<MessageResponse> CreateAsync(CreateUserRoleCommand request, CancellationToken cancellationToken);
    Task<bool> CheckIfRoleExists(CreateUserRoleCommand request);
    Task<bool> CheckIfRoleExistsByName(string userId, string roleName);
    public Task<bool> IsAdmin();
}
