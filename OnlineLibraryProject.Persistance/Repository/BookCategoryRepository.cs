using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineLibraryProject.Domain.Entities;
using OnlineLibraryProject.Domain.Repositories;
using OnlineLibraryProject.Persistance.Context;

namespace OnlineLibraryProject.Persistance.Repository;

public class BookCategoryRepository : GenericRepository<BookCategory>, IBookCategoryRepository
{
    private IQueryable<BookCategory> BookCategoryEntity => Entity.Include(e => e.Book).Include(e => e.Category);
    public BookCategoryRepository(OnlineLibraryDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public IQueryable<BookCategory> GetAll()
    {
        return BookCategoryEntity;
    }

    public IQueryable<BookCategory> GetBookCategoriesByBookId(string bookId)
    {
        return BookCategoryEntity.Where(e => e.BookId == bookId);
    }

    public IQueryable<BookCategory> GetBookCategoriesByCategoryId(string categoryId)
    {
        return BookCategoryEntity.Where(e => e.CategoryId == categoryId);
    }

    public IQueryable<BookCategory> GetBookCategoriesByCategoryIds(List<string> categoryIds)
    {
        return BookCategoryEntity.Where(e => categoryIds.Contains(e.CategoryId));
    }
}
