using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.UserBookBorrowFeatures.Commands.CreateUserBookBorrow;

public class CreateUserBookBorrowCommandHandler : UserBookBorrowHandler, IRequestHandler<CreateUserBookBorrowCommand, MessageResponse>
{
    public CreateUserBookBorrowCommandHandler(IUserBookBorrowService userBookBorrowService) : base(userBookBorrowService)
    {
    }

    public async Task<MessageResponse> Handle(CreateUserBookBorrowCommand request, CancellationToken cancellationToken)
    {
        return await _userBookBorrowService.Create(request, cancellationToken);
    }
}
