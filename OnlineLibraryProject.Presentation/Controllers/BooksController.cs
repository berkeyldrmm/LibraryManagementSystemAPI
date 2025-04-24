using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLibraryProject.Application.Features.BookFeatures.Commands.CreateBook;
using OnlineLibraryProject.Application.Features.BookFeatures.Commands.DeleteBook;
using OnlineLibraryProject.Application.Features.BookFeatures.Commands.UpdateBook;
using OnlineLibraryProject.Application.Features.BookFeatures.Queries.GetAllBooks;
using OnlineLibraryProject.Application.Features.BookFeatures.Queries.GetAllBooksPaged;
using OnlineLibraryProject.Application.Features.BookFeatures.Queries.GetBookById;
using OnlineLibraryProject.Application.Features.BookFeatures.Queries.GetBooksByFilters;
using OnlineLibraryProject.Application.Features.BookFeatures.Queries.GetPagedBooks;
using OnlineLibraryProject.Application.Features.BookFeatures.Queries.GetTopBorrowedBooks;
using OnlineLibraryProject.Application.Features.BookFeatures.Queries.GetTopRatingBooks;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Book;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookRating;
using OnlineLibraryProject.Domain.Dtos.Responses;
using OnlineLibraryProject.Infrastructure.Authorization;
using OnlineLibraryProject.Presentation.Abstraction;

namespace OnlineLibraryProject.Presentation.Controllers
{
    public class BooksController : ApiController
    {
        public BooksController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ListDataResponse<BookListDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllBooksQuery(), cancellationToken));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(DataResponse<BookDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetBookByIdQuery(id), cancellationToken));
        }

        [HttpGet("Paged")]
        [ProducesResponseType(typeof(PagedListDataResponse<BookListDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPaged(int pageSize, int pageNumber, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllBooksPagedQuery() { PageSize = pageSize, PageNumber = pageNumber }, cancellationToken));
        }

        [HttpGet("FiltersPaged")]
        [ProducesResponseType(typeof(PagedListDataResponse<BookListDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByFiltersPaged([FromBody]GetBooksByFiltersPagedQuery request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }

        [HttpGet("Filters")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ListDataResponse<BookListDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByFilters([FromQuery] GetBooksByFiltersQuery request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }

        [HttpGet("GetTopRatedBooks")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ListDataResponse<TopRatingBooksDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTopRatedBooks(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetTopRatingBooksQuery(), cancellationToken));
        }

        [HttpGet("GetTopBorrowedBooks")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ListDataResponse<TopBorrowedBooksDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTopBorrowedBooks(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetTopBorrowedBooksQuery(), cancellationToken));
        }

        [HttpPost]
        [RoleValidation("Admin")]
        [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(CreateBookCommand request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }

        [HttpPut]
        [RoleValidation("Admin")]
        [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request,cancellationToken));
        }

        [HttpDelete]
        [RoleValidation("Admin")]
        [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
    }
}
