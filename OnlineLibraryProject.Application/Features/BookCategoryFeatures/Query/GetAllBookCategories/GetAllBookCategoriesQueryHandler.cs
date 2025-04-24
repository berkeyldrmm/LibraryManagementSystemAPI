using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookCategory;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookCategoryFeatures.Query.GetAllBookCategories;

public class GetAllBookCategoriesQueryHandler : BookCategoryHandler, IRequestHandler<GetAllBookCategoriesQuery, ListDataResponse<BookCategoryListDto>>
{
    public GetAllBookCategoriesQueryHandler(IBookCategoryService bookCategoryService) : base(bookCategoryService)
    {
    }

    public async Task<ListDataResponse<BookCategoryListDto>> Handle(GetAllBookCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _bookCategoryService.GetAll();
    }
}
