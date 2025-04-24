using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Book;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.User;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.UserBookBorrow;
using OnlineLibraryProject.Domain.Entities;
using OnlineLibraryProject.Domain.Repositories;
using OnlineLibraryProject.Persistance.Context;

namespace OnlineLibraryProject.Persistance.Repository;

public class UserBookBorrowRepository : GenericRepository<UserBookBorrow>, IUserBookBorrowRepository
{
    public UserBookBorrowRepository(OnlineLibraryDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public IQueryable<GetUserBookBorrowsByUserDto> GetBookBorrowsByUser(string userId)
    {
        return Entity.Where(e => e.UserId == userId).Include(u => u.User).Include(u => u.Book).Select(u => new GetUserBookBorrowsByUserDto(u.UserId, u.User.UserName, u.User.BookBorrows.Select(b => new BorrowedBookDto(b.BookId, b.Book.Name, b.Book.ImageBase64, b.Book.AuthorName, b.BorrowDate, b.BorrowEndDate))));
    }

    public IQueryable<GetUserBookBorrowsByBookDto> GetUserBorrowsByBook(string bookId)
    {
        return Entity.Where(e => e.BookId == bookId).Include(u => u.User).Include(u => u.Book).Select(u => new GetUserBookBorrowsByBookDto(u.BookId, u.Book.Name, u.User.BookBorrows.Select(b=>new UserDto(b.User.UserName))));
    }
}