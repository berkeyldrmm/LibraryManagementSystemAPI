using OnlineLibraryProject.Application.Services;
using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.RoleFeatures.Commands.CreateRole;

public class CreateRoleHandler : RoleHandler, IRequestHandler<CreateRoleCommand, MessageResponse>
{
    public CreateRoleHandler(IRoleService roleService) : base(roleService)
    {
    }

    public async Task<MessageResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        return await _roleService.CreateAsync(request);
    }
}
