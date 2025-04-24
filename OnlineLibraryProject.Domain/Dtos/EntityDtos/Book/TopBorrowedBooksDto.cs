using OnlineLibraryProject.Domain.Abstractions;

namespace OnlineLibraryProject.Domain.Dtos.EntityDtos.Book;

public record TopBorrowedBooksDto(BookListDto book, int BorrowCount) : EntityDTO;