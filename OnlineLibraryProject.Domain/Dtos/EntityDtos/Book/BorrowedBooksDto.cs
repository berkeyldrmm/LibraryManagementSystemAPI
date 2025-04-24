using OnlineLibraryProject.Domain.Abstractions;

namespace OnlineLibraryProject.Domain.Dtos.EntityDtos.Book;

public record BorrowedBookDto(
    string Id,
    string Name,
    string ImageBase64,
    string AuthorName,
    DateTime BorrowedDate,
    DateTime BorrowEndDate) : EntityDTO<string>;
