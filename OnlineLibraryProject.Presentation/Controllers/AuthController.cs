using OnlineLibraryProject.Application.Features.AuthFeatures.Commands.ConfirmEmail;
using OnlineLibraryProject.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using OnlineLibraryProject.Application.Features.AuthFeatures.Commands.Login;
using OnlineLibraryProject.Application.Features.AuthFeatures.Commands.Register;
using OnlineLibraryProject.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineLibraryProject.Domain.Dtos.Responses;
using Microsoft.AspNetCore.Http;

namespace OnlineLibraryProject.Presentation.Controllers;

public class AuthController : ApiController
{
    public AuthController(IMediator mediator) : base(mediator) {}

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Register(RegisterCommand request)
    {
        MessageResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> ConfirmEmail([FromQuery]ConfirmEmailCommand request)
    {
        MessageResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(LoginCommandResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    [ProducesResponseType(typeof(LoginCommandResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateNewTokenByRefreshToken(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
