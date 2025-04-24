using MediatR;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookFeatures.Commands.DeleteBook;

public record DeleteBookCommand(
    string Id) : IRequest<MessageResponse>;