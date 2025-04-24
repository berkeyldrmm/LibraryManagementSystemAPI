using MediatR;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.UserBookBorrowFeatures.Commands.UpdateUserBookBorrow;

public record UpdateUserBookBorrowCommand(
    string Id,
    DateTime BorrowDate,
    DateTime BorrowEndDate,
    bool Status) : IRequest<MessageResponse>;
