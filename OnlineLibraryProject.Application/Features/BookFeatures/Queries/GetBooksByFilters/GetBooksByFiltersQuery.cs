using MediatR;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Book;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.BookFeatures.Queries.GetBooksByFilters;

public record GetBooksByFiltersQuery(string Search, bool IsEBook, bool FilterForEBook) : IRequest<ListDataResponse<BookListDto>>;