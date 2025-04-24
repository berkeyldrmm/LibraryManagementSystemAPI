using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookCategory;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookCategoryFeatures.Query.GetBookCategoriesByBookId;

public class GetBookCategoriesByBookIdQueryHandler : BookCategoryHandler, IRequestHandler<GetBookCategoriesByBookIdQuery, DataResponse<GetBookWithCategoryDto>>
{
    public GetBookCategoriesByBookIdQueryHandler(IBookCategoryService bookCategoryService) : base(bookCategoryService)
    {
    }

    public async Task<DataResponse<GetBookWithCategoryDto>> Handle(GetBookCategoriesByBookIdQuery request, CancellationToken cancellationToken)
    {
        return await _bookCategoryService.GetBookCategoriesByBookId(request.BookId);
    }
}
