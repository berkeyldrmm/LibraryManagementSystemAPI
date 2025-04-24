using MediatR;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookRatingFeatures.Command.CreateBookRating;

public record CreateBookRatingCommand(
    string BookId,
    string UserId,
    int Star) : IRequest<MessageResponse>;
