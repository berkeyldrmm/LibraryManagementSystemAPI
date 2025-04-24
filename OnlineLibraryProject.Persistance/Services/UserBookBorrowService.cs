using Microsoft.EntityFrameworkCore;
using OnlineLibraryProject.Application.Features.UserBookBorrowFeatures.Commands.CreateUserBookBorrow;
using OnlineLibraryProject.Application.Features.UserBookBorrowFeatures.Commands.UpdateUserBookBorrow;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.UserBookBorrow;
using OnlineLibraryProject.Domain.Dtos.Responses;
using OnlineLibraryProject.Domain.Entities;
using OnlineLibraryProject.Domain.Repositories;
using System.Security.Claims;

namespace OnlineLibraryProject.Persistance.Services;

public class UserBookBorrowService : GenericService<UserBookBorrow, GetUserBookBorrowsByBookDto, GetUserBookBorrowsByUserDto, CreateUserBookBorrowCommand, IUserBookBorrowRepository>, IUserBookBorrowService
{
    public UserBookBorrowService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public async Task<DataResponse<GetUserBookBorrowsByUserDto>> GetBookBorrowsByUser(string userId)
    {
        return new DataResponse<GetUserBookBorrowsByUserDto>(await _repository.GetBookBorrowsByUser(userId).FirstOrDefaultAsync());
    }

    public async Task<DataResponse<GetUserBookBorrowsByBookDto>> GetUserBorrowsByBook(string bookId)
    {
        return new DataResponse<GetUserBookBorrowsByBookDto>(await _repository.GetUserBorrowsByBook(bookId).FirstOrDefaultAsync());
    }

    public async Task<MessageResponse> Update(UpdateUserBookBorrowCommand dto)
    {
        UserBookBorrow userBookBorrow = await _repository.GetByIdAsync(dto.Id);

        if (userBookBorrow.UserId == _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value)
        {
            userBookBorrow.BorrowDate = dto.BorrowDate;
            userBookBorrow.BorrowEndDate = dto.BorrowEndDate;
            userBookBorrow.Status = dto.Status;

            _ = _repository.Update(userBookBorrow);
            _ = await _unitOfWork.SaveChangesAsync();

            return new("User's book borrow information has been updated successfully");
        }

        throw new Exception("You do not have a permission to update this entity.");
    }
}
