using MediatR;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookCategoryFeatures.Command.CreateBookCategory;

public record CreateBookCategoryCommand(
    string BookId,
    string CategoryId) : IRequest<MessageResponse>;
