using MediatR;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookFeatures.Commands.UpdateBook;

public record UpdateBookCommand(
    string Id,
    string Name,
    string AuthorName,
    string NumberOfPages,
    string Stock,
    string Description,
    string ImageBase64,
    bool IsEBook,
    string? EBookUrl) : IRequest<MessageResponse>;

