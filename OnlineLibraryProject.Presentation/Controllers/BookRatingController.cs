using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLibraryProject.Application.Features.BookRatingFeatures.Command.CreateBookRating;
using OnlineLibraryProject.Application.Features.BookRatingFeatures.Command.DeleteBookRating;
using OnlineLibraryProject.Application.Features.BookRatingFeatures.Command.UpdateBookRating;
using OnlineLibraryProject.Application.Features.BookRatingFeatures.Queries.GetBookRatings;
using OnlineLibraryProject.Application.Features.BookRatingFeatures.Queries.GetBookRatingsByUser;
using OnlineLibraryProject.Domain.Dtos.Responses;
using OnlineLibraryProject.Presentation.Abstraction;

namespace OnlineLibraryProject.Presentation.Controllers;

public class BookRatingController : ApiController
{
    public BookRatingController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("GetBookRatings/{bookId}")]
    public async Task<IActionResult> GetBookRatings(string bookId, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetBookRatingsQuery(bookId), cancellationToken));
    }

    [HttpGet("GetBookRatingsByUser/{userId}")]
    public async Task<IActionResult> GetBookRatingsByUser(string userId, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetBookRatingsByUserQuery(userId), cancellationToken));
    }

    [HttpPost]
    [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Add(CreateBookRatingCommand request, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(request, cancellationToken));
    }

    [HttpPut]
    [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update(UpdateBookRatingCommand request, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(request, cancellationToken));
    }

    [HttpDelete]
    [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(DeleteBookRatingCommand request, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(request, cancellationToken));
    }
}
