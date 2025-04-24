using OnlineLibraryProject.Domain.Abstractions;

namespace OnlineLibraryProject.Domain.Dtos.EntityDtos.BookCategory;

public record GetBookWithCategoryDto(string bookId, string Name, string ImageBase64, string AuthorName, string NumberOfPages, bool IsEbook, IEnumerable<string> Categories) : EntityDTO;