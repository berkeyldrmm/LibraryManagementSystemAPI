using OnlineLibraryProject.Domain.Entities;

namespace OnlineLibraryProject.Domain.Repositories;

public interface IUserRoleRepository : IGenericRepository<UserRole>
{
    Task<bool> CheckIfRoleExists(string userId, string roleId);
    Task<bool> CheckIfRoleExistsByName(string userId, string roleName);
}
