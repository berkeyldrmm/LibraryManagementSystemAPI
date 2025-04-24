using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookRatingFeatures.Command.UpdateBookRating;

public class UpdateBookRatingCommandHandler : BookRatingHandler, IRequestHandler<UpdateBookRatingCommand, MessageResponse>
{
    public UpdateBookRatingCommandHandler(IBookRatingService bookRatingService) : base(bookRatingService)
    {
    }

    public async Task<MessageResponse> Handle(UpdateBookRatingCommand request, CancellationToken cancellationToken)
    {
        return await _bookRatingService.Update(request);
    }
}
