using OnlineLibraryProject.Domain.Abstractions;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.User;

namespace OnlineLibraryProject.Domain.Dtos.EntityDtos.UserBookBorrow;

public record GetUserBookBorrowsByBookDto(string BookId, string BookName, IEnumerable<UserDto> Users) : EntityDTO<string>;
