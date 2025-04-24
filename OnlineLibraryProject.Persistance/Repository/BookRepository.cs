using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Book;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookRating;
using OnlineLibraryProject.Domain.Entities;
using OnlineLibraryProject.Domain.Repositories;
using OnlineLibraryProject.Persistance.Context;
using System.Collections;

namespace OnlineLibraryProject.Persistance.Repository;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(OnlineLibraryDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<BookDto> GetOneAsync(string id)
    {
        return await Entity.Where(x => x.Id == id).Include(x=>x.Categories).AsNoTracking().Select(b=>new BookDto(b.Id,
            b.Name,
            b.AuthorName,
            b.Categories.Select(c => c.Category.Name).ToList(),
            b.NumberOfPages,
            b.Description,
            b.ImageBase64,
            b.IsEbook,
            b.EBookUrl)).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<TopBorrowedBooksDto>> GetTopBorrowedBooks()
    {
        return await Entity
        .Include(b=>b.UserBookBorrows)
        .Select(book => new TopBorrowedBooksDto(_mapper.Map<BookListDto>(book), book.UserBookBorrows.Count()))
        .ToListAsync();
    }

    public async Task<IEnumerable<TopRatingBooksDto>> GetTopRatingBooks()
    {
        return await Entity
        .Include(b => b.Ratings) 
        .Where(b => b.Ratings.Any())
        .Select(b => new TopRatingBooksDto(b.Id, b.Name, b.AuthorName, b.NumberOfPages, b.ImageBase64, Math.Round(b.Ratings.Average(r => r.Star), 1), b.Ratings.Count()))
        .ToListAsync();
    }
}
