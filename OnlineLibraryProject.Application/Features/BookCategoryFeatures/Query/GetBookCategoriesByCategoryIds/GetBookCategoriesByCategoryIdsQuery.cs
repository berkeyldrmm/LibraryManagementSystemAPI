using MediatR;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookCategory;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookCategoryFeatures.Query.GetBookCategoriesByCategoryIds;

public record GetBookCategoriesByCategoryIdsQuery(List<string> categoryIds) : IRequest<ListDataResponse<BookCategoryListDto>>;