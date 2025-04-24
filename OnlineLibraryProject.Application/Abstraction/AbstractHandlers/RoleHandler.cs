using OnlineLibraryProject.Application.Services;

namespace OnlineLibraryProject.Application.Abstraction.AbstractHandlers;

public abstract class RoleHandler
{
    public IRoleService _roleService { get; set; }

    protected RoleHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }
}
