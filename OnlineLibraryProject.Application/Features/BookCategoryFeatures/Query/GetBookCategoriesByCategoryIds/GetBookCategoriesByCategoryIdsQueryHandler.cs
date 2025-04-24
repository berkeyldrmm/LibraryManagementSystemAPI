using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookCategory;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookCategoryFeatures.Query.GetBookCategoriesByCategoryIds;

public class GetBookCategoriesByCategoryIdsQueryHandler : BookCategoryHandler, IRequestHandler<GetBookCategoriesByCategoryIdsQuery, ListDataResponse<BookCategoryListDto>>
{
    public GetBookCategoriesByCategoryIdsQueryHandler(IBookCategoryService bookCategoryService) : base(bookCategoryService)
    {
    }

    public async Task<ListDataResponse<BookCategoryListDto>> Handle(GetBookCategoriesByCategoryIdsQuery request, CancellationToken cancellationToken)
    {
        return await _bookCategoryService.GetBookCategoriesByCategoryIds(request.categoryIds);
    }
}
