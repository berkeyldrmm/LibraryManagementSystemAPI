using MediatR;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Book;
using OnlineLibraryProject.Domain.Dtos.Requests;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookFeatures.Queries.GetPagedBooks;

public class GetBooksByFiltersPagedQuery : PageRequest, IRequest<PagedListDataResponse<BookListDto>>
{
    public string Search {  get; set; }
    public bool FilterForEBook { get; set; }
    public bool IsEBook {  get; set; }
}