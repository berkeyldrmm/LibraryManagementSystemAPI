using OnlineLibraryProject.Domain.Entities;

namespace OnlineLibraryProject.Domain.Repositories;

public interface IBookCategoryRepository : IGenericRepository<BookCategory>
{
    IQueryable<BookCategory> GetAll();
    IQueryable<BookCategory> GetBookCategoriesByBookId(string bookId);
    IQueryable<BookCategory> GetBookCategoriesByCategoryId(string categoryId);
    IQueryable<BookCategory> GetBookCategoriesByCategoryIds(List<string> categoryIds);
}
