﻿using OnlineLibraryProject.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using OnlineLibraryProject.Application.Features.AuthFeatures.Commands.Login;
using OnlineLibraryProject.Application.Features.AuthFeatures.Commands.Register;

namespace OnlineLibraryProject.Application.Services;

public interface IAuthService
{
    Task Register(RegisterCommand command);
    Task SendConfirmEmail(string id);
    Task ConfirmEmail(string userId, string token);
    Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken);
    Task<LoginCommandResponse> CreateNewTokenByRefreshToken(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken);
}
