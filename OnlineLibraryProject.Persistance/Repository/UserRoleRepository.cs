using AutoMapper;
using OnlineLibraryProject.Domain.Entities;
using OnlineLibraryProject.Domain.Repositories;
using OnlineLibraryProject.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace OnlineLibraryProject.Persistance.Repository;

public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(OnlineLibraryDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<bool> CheckIfRoleExists(string userId, string roleId)
    {
        return await Entity.Where(ur => ur.UserId == userId).Where(ur => ur.RoleId == roleId).AnyAsync();
    }

    public async Task<bool> CheckIfRoleExistsByName(string userId, string roleName)
    {
        return await Entity.Where(ur => ur.UserId == userId).Include(ur => ur.Role).AnyAsync(ur => ur.Role.Name == roleName);
    }
}
