using MediatR;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.UserBookBorrowFeatures.Commands.DeleteUserBookBorrow;

public record DeleteUserBookBorrowCommand(string Id) : IRequest<MessageResponse>;