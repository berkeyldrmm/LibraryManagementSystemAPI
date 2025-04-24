using MediatR;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Book;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookFeatures.Queries.GetAllBooks;

public class GetAllBooksQuery : IRequest<ListDataResponse<BookListDto>>
{

}
