using OnlineLibraryProject.Domain.Abstractions;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Book;

namespace OnlineLibraryProject.Domain.Dtos.EntityDtos.UserBookBorrow;

public record GetUserBookBorrowsByUserDto(string userId, string UserName, IEnumerable<BorrowedBookDto> Books) : EntityDTO;
