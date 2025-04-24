using OnlineLibraryProject.Domain.Abstractions;

namespace OnlineLibraryProject.Domain.Dtos.EntityDtos.BookCategory;

public record BookCategoryListDto(string bookId, string Name, string ImageBase64, string AuthorName, string NumberOfPages, bool IsEbook, string CategoryName) : EntityDTO<string>;
