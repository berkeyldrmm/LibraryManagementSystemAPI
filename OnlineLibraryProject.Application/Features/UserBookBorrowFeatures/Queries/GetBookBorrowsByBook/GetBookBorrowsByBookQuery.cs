using MediatR;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.UserBookBorrow;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.UserBookBorrowFeatures.Queries.GetBookBorrowsByBook;

public record GetBookBorrowsByBookQuery(string BookId) : IRequest<DataResponse<GetUserBookBorrowsByBookDto>>;