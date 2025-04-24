using OnlineLibraryProject.Application.Services;

namespace OnlineLibraryProject.Application.Abstraction.AbstractHandlers;

public abstract class BookCategoryHandler
{
    public IBookCategoryService _bookCategoryService { get; set; }

    protected BookCategoryHandler(IBookCategoryService bookCategoryService)
    {
        _bookCategoryService = bookCategoryService;
    }
}
