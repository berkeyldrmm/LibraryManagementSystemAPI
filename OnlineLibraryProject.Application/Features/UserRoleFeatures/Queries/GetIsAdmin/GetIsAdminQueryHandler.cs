using MediatR;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.UserRole;

namespace OnlineLibraryProject.Application.Features.UserRoleFeatures.Queries.GetIsAdmin;

public class GetIsAdminQueryHandler : IRequestHandler<GetIsAdminQuery, IsAdminDto>
{
    private readonly IUserRoleService _userRoleService;

    public GetIsAdminQueryHandler(IUserRoleService userRoleService)
    {
        _userRoleService = userRoleService;
    }

    public async Task<IsAdminDto> Handle(GetIsAdminQuery request, CancellationToken cancellationToken)
    {
        return new IsAdminDto(await _userRoleService.IsAdmin());
    }
}
