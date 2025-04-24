using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.UserBookBorrowFeatures.Commands.DeleteUserBookBorrow;

public class DeleteUserBookBorrowCommandHandler : UserBookBorrowHandler, IRequestHandler<DeleteUserBookBorrowCommand, MessageResponse>
{
    public DeleteUserBookBorrowCommandHandler(IUserBookBorrowService userBookBorrowService) : base(userBookBorrowService)
    {
    }

    public async Task<MessageResponse> Handle(DeleteUserBookBorrowCommand request, CancellationToken cancellationToken)
    {
        return await _userBookBorrowService.Delete(request.Id, cancellationToken);
    }
}
