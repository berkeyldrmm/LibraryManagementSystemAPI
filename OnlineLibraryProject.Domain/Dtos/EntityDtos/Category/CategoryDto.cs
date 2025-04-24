using OnlineLibraryProject.Domain.Abstractions;

namespace OnlineLibraryProject.Domain.Dtos.EntityDtos.Category;

public record CategoryDto(string Id, string Name) : EntityDTO;
