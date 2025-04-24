using MediatR;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Book;
using OnlineLibraryProject.Domain.Dtos.Requests;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookFeatures.Queries.GetAllBooksPaged;

public class GetAllBooksPagedQuery : PageRequest, IRequest<PagedListDataResponse<BookListDto>>
{
}
