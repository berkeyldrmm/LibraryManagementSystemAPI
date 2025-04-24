using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookCategory;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookCategoryFeatures.Query.GetBookCategoriesByCategoryId;

public class GetBookCategoriesByCategoryIdQueryHandler : BookCategoryHandler, IRequestHandler<GetBookCategoriesByCategoryIdQuery, DataResponse<GetBooksByCategoryDto>>
{
    public GetBookCategoriesByCategoryIdQueryHandler(IBookCategoryService bookCategoryService) : base(bookCategoryService)
    {
    }

    public async Task<DataResponse<GetBooksByCategoryDto>> Handle(GetBookCategoriesByCategoryIdQuery request, CancellationToken cancellationToken)
    {
        return await _bookCategoryService.GetBookCategoriesByCategoryId(request.CategoryId);
    }
}
