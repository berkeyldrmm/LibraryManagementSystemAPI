using MediatR;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookCategory;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookCategoryFeatures.Query.GetBookCategoriesByBookId;

public record GetBookCategoriesByBookIdQuery(string BookId) : IRequest<DataResponse<GetBookWithCategoryDto>>;