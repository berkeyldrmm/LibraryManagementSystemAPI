using OnlineLibraryProject.Domain.Abstractions;

namespace OnlineLibraryProject.Domain.Dtos.EntityDtos.UserRole;

public record UserRoleListDto(string UserName, string RoleName) : EntityDTO<string>;
