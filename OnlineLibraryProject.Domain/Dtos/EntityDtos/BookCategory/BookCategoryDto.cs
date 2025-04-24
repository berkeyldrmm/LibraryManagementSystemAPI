using OnlineLibraryProject.Domain.Abstractions;

namespace OnlineLibraryProject.Domain.Dtos.EntityDtos.BookCategory;

public record BookCategoryDto(string BookName, string AuthorName, string NumberOfPages, string Description, string ImageBase64, bool IsEbook, string CategoryName) : EntityDTO;
