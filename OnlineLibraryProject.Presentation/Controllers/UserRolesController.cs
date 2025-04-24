using OnlineLibraryProject.Application.Features.UserRoleFeatures.Commands.CreateUserRole;
using OnlineLibraryProject.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineLibraryProject.Domain.Dtos.Responses;
using Microsoft.AspNetCore.Http;
using OnlineLibraryProject.Infrastructure.Authorization;
using Microsoft.AspNetCore.Authorization;
using OnlineLibraryProject.Application.Features.AuthFeatures.Commands.Login;
using Org.BouncyCastle.Asn1.Ocsp;
using OnlineLibraryProject.Application.Features.UserRoleFeatures.Queries.GetIsAdmin;

namespace OnlineLibraryProject.Presentation.Controllers;

public class UserRolesController : ApiController
{
    public UserRolesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    [RoleValidation("Admin")]
    [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("IsAdmin")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(LoginCommandResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> IsAdmin(CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetIsAdminQuery(), cancellationToken));
    }
}
