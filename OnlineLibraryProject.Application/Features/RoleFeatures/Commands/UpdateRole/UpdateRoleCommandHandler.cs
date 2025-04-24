using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.RoleFeatures.Commands.UpdateRole;

public class UpdateRoleCommandHandler : RoleHandler, IRequestHandler<UpdateRoleCommand, MessageResponse>
{
    public UpdateRoleCommandHandler(IRoleService roleService) : base(roleService)
    {
    }

    public async Task<MessageResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        return await _roleService.UpdateAsync(request);
    }
}
