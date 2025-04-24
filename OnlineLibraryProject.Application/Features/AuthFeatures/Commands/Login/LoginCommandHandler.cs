﻿using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using MediatR;

namespace OnlineLibraryProject.Application.Features.AuthFeatures.Commands.Login;

public sealed class LoginCommandHandler : AuthHandler, IRequestHandler<LoginCommand, LoginCommandResponse>
{
    public LoginCommandHandler(IAuthService authService) : base(authService)
    {
    }

    public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
       return await _authService.LoginAsync(request, cancellationToken);
    }
}
