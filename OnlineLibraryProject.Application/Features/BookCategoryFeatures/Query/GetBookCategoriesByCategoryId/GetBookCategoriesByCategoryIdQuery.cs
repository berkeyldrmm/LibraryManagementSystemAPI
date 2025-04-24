using MediatR;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookCategory;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookCategoryFeatures.Query.GetBookCategoriesByCategoryId;

public record GetBookCategoriesByCategoryIdQuery(string CategoryId) : IRequest<DataResponse<GetBooksByCategoryDto>>;