namespace OnlineLibraryProject.Application.Features.AuthFeatures.Commands.Login;

public sealed record LoginCommandResponse(
    string UserId,
    string Token);
