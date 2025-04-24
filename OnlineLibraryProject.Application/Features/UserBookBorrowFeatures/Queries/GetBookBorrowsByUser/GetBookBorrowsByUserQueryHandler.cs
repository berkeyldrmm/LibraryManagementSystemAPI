using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.UserBookBorrow;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.UserBookBorrowFeatures.Queries.GetBookBorrowsByUser;

public class GetBookBorrowsByUserQueryHandler : UserBookBorrowHandler, IRequestHandler<GetBookBorrowsByUserQuery, DataResponse<GetUserBookBorrowsByUserDto>>
{
    public GetBookBorrowsByUserQueryHandler(IUserBookBorrowService userBookBorrowService) : base(userBookBorrowService)
    {
    }

    public async Task<DataResponse<GetUserBookBorrowsByUserDto>> Handle(GetBookBorrowsByUserQuery request, CancellationToken cancellationToken)
    {
        return await _userBookBorrowService.GetBookBorrowsByUser(request.UserId);
    }
}
