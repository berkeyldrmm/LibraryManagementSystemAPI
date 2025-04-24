using MediatR;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookCategory;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookCategoryFeatures.Query.GetAllBookCategories;

public record GetAllBookCategoriesQuery() : IRequest<ListDataResponse<BookCategoryListDto>>;