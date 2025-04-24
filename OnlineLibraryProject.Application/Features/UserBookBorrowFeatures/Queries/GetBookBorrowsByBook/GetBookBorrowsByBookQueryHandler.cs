using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.UserBookBorrow;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.UserBookBorrowFeatures.Queries.GetBookBorrowsByBook;

public class GetBookBorrowsByBookQueryHandler : UserBookBorrowHandler, IRequestHandler<GetBookBorrowsByBookQuery, DataResponse<GetUserBookBorrowsByBookDto>>
{
    public GetBookBorrowsByBookQueryHandler(IUserBookBorrowService userBookBorrowService) : base(userBookBorrowService)
    {
    }

    public async Task<DataResponse<GetUserBookBorrowsByBookDto>> Handle(GetBookBorrowsByBookQuery request, CancellationToken cancellationToken)
    {
        return await _userBookBorrowService.GetUserBorrowsByBook(request.BookId);
    }
}
