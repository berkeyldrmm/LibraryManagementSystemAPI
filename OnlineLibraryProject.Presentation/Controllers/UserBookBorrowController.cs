using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLibraryProject.Application.Features.BookCategoryFeatures.Query.GetAllBookCategories;
using OnlineLibraryProject.Application.Features.BookCategoryFeatures.Query.GetBookCategoriesByBookId;
using OnlineLibraryProject.Application.Features.UserBookBorrowFeatures.Commands.CreateUserBookBorrow;
using OnlineLibraryProject.Application.Features.UserBookBorrowFeatures.Commands.DeleteUserBookBorrow;
using OnlineLibraryProject.Application.Features.UserBookBorrowFeatures.Commands.UpdateUserBookBorrow;
using OnlineLibraryProject.Application.Features.UserBookBorrowFeatures.Queries.GetBookBorrowsByBook;
using OnlineLibraryProject.Application.Features.UserBookBorrowFeatures.Queries.GetBookBorrowsByUser;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Book;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.UserBookBorrow;
using OnlineLibraryProject.Domain.Dtos.Responses;
using OnlineLibraryProject.Infrastructure.Authorization;
using OnlineLibraryProject.Presentation.Abstraction;
using System.Security.Claims;

namespace OnlineLibraryProject.Presentation.Controllers;

public class UserBookBorrowController : ApiController
{
    public IHttpContextAccessor _contextAccessor { get; set; }
    public UserBookBorrowController(IMediator mediator, IHttpContextAccessor contextAccessor) : base(mediator)
    {
        _contextAccessor = contextAccessor;
    }

    [HttpGet("GetBookBorrowsByUser/{userId}")]
    [RoleValidation("Admin")]
    [ProducesResponseType(typeof(DataResponse<GetUserBookBorrowsByUserDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBookBorrowsByUser(string userId, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetBookBorrowsByUserQuery(userId), cancellationToken));
    }

    [HttpGet("GetUserBorrowsByBook/{bookId}")]
    [RoleValidation("Admin")]
    [ProducesResponseType(typeof(DataResponse<GetUserBookBorrowsByBookDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUserBorrowsByBook(string bookId, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetBookBorrowsByBookQuery(bookId), cancellationToken));
    }

    [HttpGet("GetBookBorrows")]
    [ProducesResponseType(typeof(DataResponse<GetUserBookBorrowsByBookDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBookBorrows(CancellationToken cancellationToken)
    {
        var userId = _contextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Ok(await _mediator.Send(new GetBookBorrowsByUserQuery(userId), cancellationToken));
    }

    [HttpPost]
    [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(CreateUserBookBorrowCommand request, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(request, cancellationToken));
    }

    [HttpPut]
    [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update(UpdateUserBookBorrowCommand request, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(request, cancellationToken));
    }

    [HttpDelete]
    [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(DeleteUserBookBorrowCommand request, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(request, cancellationToken));
    }
}
