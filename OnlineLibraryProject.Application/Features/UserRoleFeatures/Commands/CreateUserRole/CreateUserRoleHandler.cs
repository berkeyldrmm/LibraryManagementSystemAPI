using OnlineLibraryProject.Application.Services;
using MediatR;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.UserRoleFeatures.Commands.CreateUserRole;

public class CreateUserRoleHandler : IRequestHandler<CreateUserRoleCommand, MessageResponse>
{
    private readonly IUserRoleService _userRoleService;

    public CreateUserRoleHandler(IUserRoleService userRoleService)
    {
        _userRoleService = userRoleService;
    }

    public async Task<MessageResponse> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        return await _userRoleService.CreateAsync(request, cancellationToken);
    }
}
