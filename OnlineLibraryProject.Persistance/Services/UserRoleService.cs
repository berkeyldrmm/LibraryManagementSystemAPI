using Microsoft.AspNetCore.Http;
using OnlineLibraryProject.Application.Features.UserRoleFeatures.Commands.CreateUserRole;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.UserRole;
using OnlineLibraryProject.Domain.Dtos.Responses;
using OnlineLibraryProject.Domain.Entities;
using OnlineLibraryProject.Domain.Repositories;
using System.Security.Claims;

namespace OnlineLibraryProject.Persistance.Services;

public class UserRoleService : GenericService<UserRole, UserRoleListDto, UserRoleDto, CreateUserRoleCommand, IUserRoleRepository>, IUserRoleService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public UserRoleService(IServiceProvider serviceProvider, IHttpContextAccessor httpContextAccessor) : base(serviceProvider)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<bool> CheckIfRoleExists(CreateUserRoleCommand request)
    {
        return await _repository.CheckIfRoleExists(request.UserId, request.RoleId);
    }

    public async Task<bool> CheckIfRoleExistsByName(string userId, string roleName)
    {
        return await _repository.CheckIfRoleExistsByName(userId, roleName);
    }

    public async Task<MessageResponse> CreateAsync(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        bool exists = await CheckIfRoleExists(request);
        if (!exists)
        {
            UserRole userRole = new()
            {
                UserId = request.UserId,
                RoleId = request.RoleId
            };

            _ = await _repository.AddAsync(userRole, cancellationToken);
            _ = await _unitOfWork.SaveChangesAsync();

            return new MessageResponse("Role has been assigned to the user successfully!");
        }

        throw new Exception("Role has already been assigned to the user!");
    }

    public async Task<bool> IsAdmin()
    {
        var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return await _repository.CheckIfRoleExists(userId, "8be970cc-9af0-44d6-919c-53442b828a46");
    }
}
