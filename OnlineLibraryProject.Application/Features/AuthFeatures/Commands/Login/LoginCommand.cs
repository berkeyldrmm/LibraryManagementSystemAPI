using MediatR;

namespace OnlineLibraryProject.Application.Features.AuthFeatures.Commands.Login;

public sealed record LoginCommand(
    string UsernameOrEmail,
    string Password) : IRequest<LoginCommandResponse>;
