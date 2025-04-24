using MediatR;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookRatingFeatures.Command.UpdateBookRating;

public record UpdateBookRatingCommand(
    string Id,
    int Rating) : IRequest<MessageResponse>;
