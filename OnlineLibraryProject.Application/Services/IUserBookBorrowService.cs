using OnlineLibraryProject.Application.Features.UserBookBorrowFeatures.Commands.CreateUserBookBorrow;
using OnlineLibraryProject.Application.Features.UserBookBorrowFeatures.Commands.UpdateUserBookBorrow;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.UserBookBorrow;
using OnlineLibraryProject.Domain.Dtos.Responses;
using OnlineLibraryProject.Domain.Entities;

namespace OnlineLibraryProject.Application.Services;

public interface IUserBookBorrowService : IGenericService<UserBookBorrow, GetUserBookBorrowsByBookDto, GetUserBookBorrowsByUserDto, CreateUserBookBorrowCommand>, IUpdateable<UpdateUserBookBorrowCommand>
{
    Task<DataResponse<GetUserBookBorrowsByUserDto>> GetBookBorrowsByUser(string userId);
    Task<DataResponse<GetUserBookBorrowsByBookDto>> GetUserBorrowsByBook(string bookId);
}
