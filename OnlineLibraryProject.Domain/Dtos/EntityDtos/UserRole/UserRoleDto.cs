using OnlineLibraryProject.Domain.Abstractions;

namespace OnlineLibraryProject.Domain.Dtos.EntityDtos.UserRole;

public record UserRoleDto(string UserName, string RoleName) : EntityDTO;
