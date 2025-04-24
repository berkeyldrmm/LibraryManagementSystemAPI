using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLibraryProject.Application.Features.CategoryFeatures.Commands.CreateCategory;
using OnlineLibraryProject.Application.Features.CategoryFeatures.Commands.DeleteCategory;
using OnlineLibraryProject.Application.Features.CategoryFeatures.Commands.UpdateCategory;
using OnlineLibraryProject.Application.Features.CategoryFeatures.Queries.GetAllCategories;
using OnlineLibraryProject.Application.Features.CategoryFeatures.Queries.GetAllCategoriesPaged;
using OnlineLibraryProject.Application.Features.CategoryFeatures.Queries.GetCategoriesByFiltersPaged;
using OnlineLibraryProject.Application.Features.CategoryFeatures.Queries.GetCategoryById;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Book;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Category;
using OnlineLibraryProject.Domain.Dtos.Responses;
using OnlineLibraryProject.Infrastructure.Authorization;
using OnlineLibraryProject.Presentation.Abstraction;

namespace OnlineLibraryProject.Presentation.Controllers;

public class CategoriesController : ApiController
{
    public CategoriesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ListDataResponse<CategoryListDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetAllCategoriesQuery(), cancellationToken));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(DataResponse<CategoryDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(string id, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetCategoryByIdQuery(id), cancellationToken));
    }

    [HttpGet("Paged")]
    [ProducesResponseType(typeof(PagedListDataResponse<CategoryListDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllPaged(GetAllCategoriesPagedQuery request, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(request, cancellationToken));
    }

    [HttpGet("FiltersPaged")]
    [ProducesResponseType(typeof(PagedListDataResponse<CategoryListDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByFiltersPaged([FromBody] GetCategoriesByFiltersPagedQuery request, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(request, cancellationToken));
    }

    [HttpPost]
    [RoleValidation("Admin")]
    [ProducesResponseType(typeof(DataResponse<CategoryDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(request, cancellationToken));
    }

    [HttpPut]
    [RoleValidation("Admin")]
    [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(request, cancellationToken));
    }

    [HttpDelete]
    [RoleValidation("Admin")]
    [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(request, cancellationToken));
    }
}
