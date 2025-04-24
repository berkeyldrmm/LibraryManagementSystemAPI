using OnlineLibraryProject.Application.Features.BookCategoryFeatures.Command.CreateBookCategory;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookCategory;
using OnlineLibraryProject.Domain.Dtos.Responses;
using OnlineLibraryProject.Domain.Entities;
using OnlineLibraryProject.Domain.Repositories;
using OnlineLibraryProject.Persistance.Mapping;

namespace OnlineLibraryProject.Persistance.Services;

public class BookCategoryService : GenericService<BookCategory, BookCategoryListDto, BookCategoryDto, CreateBookCategoryCommand, IBookCategoryRepository>, IBookCategoryService
{
    public BookCategoryService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public async Task<ListDataResponse<BookCategoryListDto>> GetAll()
    {
        var datas = _repository.GetAll();
        IEnumerable<BookCategoryListDto> value = await datas.ToBookCategoryListDto();

        return new ListDataResponse<BookCategoryListDto>(value);
    }

    public async Task<DataResponse<GetBookWithCategoryDto>> GetBookCategoriesByBookId(string bookId)
    {
        var datas = _repository.GetBookCategoriesByBookId(bookId);
        GetBookWithCategoryDto value = await datas.ToGetBookWithCategoriesDto();
        if(value == null)
        {
            throw new Exception("Book could not found");
        }

        return new DataResponse<GetBookWithCategoryDto>(value);
    }

    public async Task<DataResponse<GetBooksByCategoryDto>> GetBookCategoriesByCategoryId(string categoryId)
    {
        var datas = _repository.GetBookCategoriesByCategoryId(categoryId);
        if (!datas.Any())
            return new DataResponse<GetBooksByCategoryDto>(new GetBooksByCategoryDto([], null));

        GetBooksByCategoryDto value = await datas.ToGetBooksByCategoryDto();

        return new DataResponse<GetBooksByCategoryDto>(value);
    }

    public async Task<ListDataResponse<BookCategoryListDto>> GetBookCategoriesByCategoryIds(List<string> categoryIds)
    {
        var datas = _repository.GetBookCategoriesByCategoryIds(categoryIds);
        IEnumerable<BookCategoryListDto> value = await datas.ToBookCategoryListDto();

        return new ListDataResponse<BookCategoryListDto>(value);
    }
}
