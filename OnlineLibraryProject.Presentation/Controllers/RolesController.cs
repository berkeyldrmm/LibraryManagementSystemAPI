using OnlineLibraryProject.Application.Features.RoleFeatures.Commands.CreateRole;
using OnlineLibraryProject.Infrastructure.Authorization;
using OnlineLibraryProject.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Presentation.Controllers;

public class RolesController : ApiController
{
    public RolesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    [RoleValidation("Admin")]
    [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(CreateRoleCommand request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
