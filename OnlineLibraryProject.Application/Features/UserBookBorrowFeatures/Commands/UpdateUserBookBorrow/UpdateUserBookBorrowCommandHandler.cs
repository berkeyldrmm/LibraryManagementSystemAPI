using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.UserBookBorrowFeatures.Commands.UpdateUserBookBorrow;

public class UpdateUserBookBorrowCommandHandler : UserBookBorrowHandler, IRequestHandler<UpdateUserBookBorrowCommand, MessageResponse>
{
    public UpdateUserBookBorrowCommandHandler(IUserBookBorrowService userBookBorrowService) : base(userBookBorrowService)
    {
    }

    public async Task<MessageResponse> Handle(UpdateUserBookBorrowCommand request, CancellationToken cancellationToken)
    {
        return await _userBookBorrowService.Update(request);
    }
}
