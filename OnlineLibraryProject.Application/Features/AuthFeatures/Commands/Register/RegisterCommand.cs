using MediatR;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.AuthFeatures.Commands.Register;

public sealed record RegisterCommand(
    string NameSurname,
    string Email,
    string? PhoneNumber,
    string Username,
    string Password,
    string PasswordConfirm) : IRequest<MessageResponse>;