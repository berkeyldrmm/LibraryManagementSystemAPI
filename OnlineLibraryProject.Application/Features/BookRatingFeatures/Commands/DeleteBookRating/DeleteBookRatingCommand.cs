using MediatR;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookRatingFeatures.Command.DeleteBookRating;

public record DeleteBookRatingCommand(string Id) : IRequest<MessageResponse>;