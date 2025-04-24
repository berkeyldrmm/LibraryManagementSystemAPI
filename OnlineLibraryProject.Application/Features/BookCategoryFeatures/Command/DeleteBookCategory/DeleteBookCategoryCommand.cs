using MediatR;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookCategoryFeatures.Command.DeleteBookCategory;

public record DeleteBookCategoryCommand(string Id) : IRequest<MessageResponse>;