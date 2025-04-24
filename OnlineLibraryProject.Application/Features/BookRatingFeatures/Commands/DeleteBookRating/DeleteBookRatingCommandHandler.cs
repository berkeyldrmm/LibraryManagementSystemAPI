using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookRatingFeatures.Command.DeleteBookRating;

public class DeleteBookRatingCommandHandler : BookRatingHandler, IRequestHandler<DeleteBookRatingCommand, MessageResponse>
{
    public DeleteBookRatingCommandHandler(IBookRatingService bookRatingService) : base(bookRatingService)
    {
    }

    public async Task<MessageResponse> Handle(DeleteBookRatingCommand request, CancellationToken cancellationToken)
    {
        return await _bookRatingService.Delete(request.Id, cancellationToken);
    }
}
