using OnlineLibraryProject.Domain.Dtos.EntityDtos.UserBookBorrow;
using OnlineLibraryProject.Domain.Entities;

namespace OnlineLibraryProject.Domain.Repositories;

public interface IUserBookBorrowRepository : IGenericRepository<UserBookBorrow>
{
    IQueryable<GetUserBookBorrowsByUserDto> GetBookBorrowsByUser(string userId);
    IQueryable<GetUserBookBorrowsByBookDto> GetUserBorrowsByBook(string bookId);
}
