using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLibraryProject.Application.Features.BookCategoryFeatures.Command.CreateBookCategory;
using OnlineLibraryProject.Application.Features.BookCategoryFeatures.Command.DeleteBookCategory;
using OnlineLibraryProject.Application.Features.BookCategoryFeatures.Query.GetAllBookCategories;
using OnlineLibraryProject.Application.Features.BookCategoryFeatures.Query.GetBookCategoriesByBookId;
using OnlineLibraryProject.Application.Features.BookCategoryFeatures.Query.GetBookCategoriesByCategoryId;
using OnlineLibraryProject.Application.Features.BookCategoryFeatures.Query.GetBookCategoriesByCategoryIds;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookCategory;
using OnlineLibraryProject.Domain.Dtos.Responses;
using OnlineLibraryProject.Presentation.Abstraction;

namespace OnlineLibraryProject.Presentation.Controllers;

public class BookCategoryController : ApiController
{
    public BookCategoryController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [ProducesResponseType(typeof(ListDataResponse<BookCategoryListDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetAllBookCategoriesQuery(), cancellationToken));
    }

    [HttpGet("GetByBookId")]
    [ProducesResponseType(typeof(DataResponse<BookCategoryDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByBookId(string bookId, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetBookCategoriesByBookIdQuery(bookId), cancellationToken));
    }

    [HttpGet("GetByCategoryId")]
    [ProducesResponseType(typeof(DataResponse<GetBooksByCategoryDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByCategoryId(string categoryId, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetBookCategoriesByCategoryIdQuery(categoryId), cancellationToken));
    }

    [HttpGet("GetByCategoryIds")]
    [ProducesResponseType(typeof(ListDataResponse<BookCategoryListDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByCategoryIds(List<string> categoryIds, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetBookCategoriesByCategoryIdsQuery(categoryIds), cancellationToken));
    }

    [HttpPost]
    [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Add(CreateBookCategoryCommand request, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(request, cancellationToken));
    }

    [HttpDelete]
    [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(DeleteBookCategoryCommand request, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(request, cancellationToken));
    }
}
