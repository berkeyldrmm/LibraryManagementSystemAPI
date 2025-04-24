using MediatR;
using OnlineLibraryProject.Domain.Dtos.Responses;
using System;

namespace OnlineLibraryProject.Application.Features.UserBookBorrowFeatures.Commands.CreateUserBookBorrow;

public record CreateUserBookBorrowCommand(
    string BookId,
    DateTime BorrowDate,
    DateTime BorrowEndDate,
    bool Status) : IRequest<MessageResponse>;
