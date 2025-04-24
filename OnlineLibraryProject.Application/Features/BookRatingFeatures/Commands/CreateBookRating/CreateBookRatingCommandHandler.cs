using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookRatingFeatures.Command.CreateBookRating;

public class CreateBookRatingCommandHandler : BookRatingHandler, IRequestHandler<CreateBookRatingCommand, MessageResponse>
{
    public CreateBookRatingCommandHandler(IBookRatingService bookRatingService) : base(bookRatingService)
    {
    }

    public async Task<MessageResponse> Handle(CreateBookRatingCommand request, CancellationToken cancellationToken)
    {
        return await _bookRatingService.Create(request, cancellationToken);
    }
}
