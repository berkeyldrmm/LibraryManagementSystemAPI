using OnlineLibraryProject.Application.Features.RoleFeatures.Commands.CreateRole;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Entities;
using OnlineLibraryProject.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using OnlineLibraryProject.Application.Features.RoleFeatures.Commands.UpdateRole;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Persistance.Services;

public class RoleService : IRoleService
{
    private readonly RoleManager<Role> _roleManager;
    private readonly IUnitOfWork _unitOfWork;
    public RoleService(RoleManager<Role> roleManager, IUnitOfWork unitOfWork)
    {
        _roleManager = roleManager;
        _unitOfWork = unitOfWork;
    }

    public async Task<MessageResponse> CreateAsync(CreateRoleCommand request)
    {
        Role role = new()
        {
            Name = request.Name
        };

        _ = await _roleManager.CreateAsync(role);
        _ = await _unitOfWork.SaveChangesAsync();

        return new("Role has been created successfully!");
    }

    public async Task<MessageResponse> UpdateAsync(UpdateRoleCommand request)
    {
        Role role = new()
        {
            Id = request.Id,
            Name = request.Name
        };
        
        _ = await _roleManager.UpdateAsync(role);
        _ = await _unitOfWork.SaveChangesAsync();

        return new("Role has been updated successfully");
    }
}
