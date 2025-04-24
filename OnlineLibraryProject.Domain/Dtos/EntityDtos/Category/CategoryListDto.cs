using OnlineLibraryProject.Domain.Abstractions;

namespace OnlineLibraryProject.Domain.Dtos.EntityDtos.Category;

public record CategoryListDto(string Name) : EntityDTO<string>;
