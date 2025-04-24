using MediatR;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Book;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookFeatures.Commands.CreateBook;

public record CreateBookCommand(
    string Name,
    string AuthorName,
    string NumberOfPages,
    string Stock,
    string Description,
    string ImageBase64,
    bool IsEBook,
    string? EBookUrl) : IRequest<DataResponse<CreatedBookDto>>;
