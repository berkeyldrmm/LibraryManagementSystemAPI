using OnlineLibraryProject.Application.Features.BookCategoryFeatures.Command.CreateBookCategory;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookCategory;
using OnlineLibraryProject.Domain.Dtos.Responses;
using OnlineLibraryProject.Domain.Entities;

namespace OnlineLibraryProject.Application.Services;

public interface IBookCategoryService : IGenericService<BookCategory, BookCategoryListDto, BookCategoryDto, CreateBookCategoryCommand>
{
    public Task<ListDataResponse<BookCategoryListDto>> GetAll();
    public Task<DataResponse<GetBookWithCategoryDto>> GetBookCategoriesByBookId(string bookId);
    public Task<DataResponse<GetBooksByCategoryDto>> GetBookCategoriesByCategoryId(string categoryId);
    public Task<ListDataResponse<BookCategoryListDto>> GetBookCategoriesByCategoryIds(List<string> categoryIds);
}
