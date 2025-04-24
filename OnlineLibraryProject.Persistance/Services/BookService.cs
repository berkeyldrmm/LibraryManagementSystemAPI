using Microsoft.EntityFrameworkCore;
using OnlineLibraryProject.Application.Features.BookFeatures.Commands.CreateBook;
using OnlineLibraryProject.Application.Features.BookFeatures.Commands.UpdateBook;
using OnlineLibraryProject.Application.Features.BookFeatures.Queries.GetBooksByFilters;
using OnlineLibraryProject.Application.Features.BookFeatures.Queries.GetPagedBooks;
using OnlineLibraryProject.Application.Features.CategoryFeatures.Commands.CreateCategory;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Book;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookRating;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Category;
using OnlineLibraryProject.Domain.Dtos.Requests;
using OnlineLibraryProject.Domain.Dtos.Responses;
using OnlineLibraryProject.Domain.Entities;
using OnlineLibraryProject.Domain.Repositories;
using OnlineLibraryProject.Persistance.Pagination;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Claims;

namespace OnlineLibraryProject.Persistance.Services;

public class BookService : GenericService<Book, BookListDto, BookDto, CreateBookCommand, IBookRepository>, IBookService
{
    public BookService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public async Task<DataResponse<CreatedBookDto>> CreateBook(CreateBookCommand dto, CancellationToken cancellationToken)
    {
        Book entity = _mapper.Map<Book>(dto);

        var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!string.IsNullOrEmpty(userId))
        {
            var userIdProp = typeof(Category).GetProperty("UserId", BindingFlags.Public | BindingFlags.Instance);
            if (userIdProp != null && userIdProp.CanWrite)
            {
                var convertedId = Convert.ChangeType(userId, userIdProp.PropertyType);
                userIdProp.SetValue(entity, convertedId);
            }
        }

        _ = await _repository.AddAsync(entity, cancellationToken);
        _ = await _unitOfWork.SaveChangesAsync();

        return new DataResponse<CreatedBookDto>(new CreatedBookDto { Id = entity.Id});
    }

    public new async Task<DataResponse<BookDto>> GetByIdAsync(string id)
    {
        BookDto data = await _repository.GetOneAsync(id);
        return new DataResponse<BookDto>(data);
    }

    public async Task<PagedListDataResponse<BookListDto>> GetAllPaged(PageRequest request)
    {
        return await _repository.GetAll<BookListDto>().PagedListResponse(request.PageSize, request.PageNumber);
    }

    public async Task<PagedListDataResponse<BookListDto>> GetPagedByFilters(GetBooksByFiltersPagedQuery dto)
    {
        var exp = new List<Expression<Func<Book, bool>>>();
        if (dto.Search != null || dto.Search != string.Empty)
        {
            string lower = dto.Search.ToLower();
            exp.Add(b => b.Name.ToLower().Contains(lower)
            || b.AuthorName.ToLower().Contains(lower)
            || b.Description.ToLower().Contains(lower));
        }
        if (dto.FilterForEBook)
            exp.Add(b => b.IsEbook == dto.IsEBook);

        return await _repository.GetByFilters<BookListDto>(exp).PagedListResponse(dto.PageSize, dto.PageNumber);
    }

    public async Task<ListDataResponse<BookListDto>> GetByFilters(GetBooksByFiltersQuery dto)
    {
        var exp = new List<Expression<Func<Book, bool>>>();
        if (dto.Search != null && dto.Search != string.Empty)
        {
            string lower = dto.Search.ToLower();
            exp.Add(b => b.Name.ToLower().Contains(lower)
            || b.AuthorName.ToLower().Contains(lower)
            || b.Description.ToLower().Contains(lower));
        }
        if (dto.FilterForEBook)
            exp.Add(b => b.IsEbook == dto.IsEBook);

        return new ListDataResponse<BookListDto>(await _repository.GetByFilters<BookListDto>(exp).ToListAsync());
    }

    public async Task<ListDataResponse<TopRatingBooksDto>> GetTopRatingBooks(int count = 4)
    {
        var booksWithRatings = await _repository.GetTopRatingBooks();

        var topRatedBooks = booksWithRatings
            .OrderByDescending(b => b.Rating)
            .ThenByDescending(b => b.RatingCount)
            .Take(count)
            .ToList();

        return new ListDataResponse<TopRatingBooksDto>(topRatedBooks);
    }

    public async Task<MessageResponse> Update(UpdateBookCommand dto)
    {
        Book book = _mapper.Map<Book>(dto);
        _ = _repository.Update(book);
        _ = await _unitOfWork.SaveChangesAsync();

        return new("Book has been updated successfully");
    }

    public async Task<ListDataResponse<TopBorrowedBooksDto>> GetTopBorrowedBooks()
    {
        var topBorrowedBooks = await _repository.GetTopBorrowedBooks();
        var books = topBorrowedBooks
        .OrderByDescending(b => b.BorrowCount)
        .Take(4)
        .ToList();
        return new ListDataResponse<TopBorrowedBooksDto>(books);
    }
}
