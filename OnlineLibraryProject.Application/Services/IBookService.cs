using OnlineLibraryProject.Application.Features.BookFeatures.Commands.CreateBook;
using OnlineLibraryProject.Application.Features.BookFeatures.Commands.UpdateBook;
using OnlineLibraryProject.Application.Features.BookFeatures.Queries.GetBooksByFilters;
using OnlineLibraryProject.Application.Features.BookFeatures.Queries.GetPagedBooks;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Book;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookRating;
using OnlineLibraryProject.Domain.Dtos.Responses;
using OnlineLibraryProject.Domain.Entities;

namespace OnlineLibraryProject.Application.Services;

public interface IBookService : IGenericService<Book, BookListDto, BookDto, CreateBookCommand>, IUpdateable<UpdateBookCommand>, IPaged<BookListDto, GetBooksByFiltersPagedQuery>
{
    Task<DataResponse<CreatedBookDto>> CreateBook(CreateBookCommand dto, CancellationToken cancellationToken);
    Task<ListDataResponse<TopRatingBooksDto>> GetTopRatingBooks(int count = 4);
    Task<ListDataResponse<TopBorrowedBooksDto>> GetTopBorrowedBooks();
    Task<ListDataResponse<BookListDto>> GetByFilters(GetBooksByFiltersQuery dto);

}

