using MediatR;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.UserBookBorrow;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.UserBookBorrowFeatures.Queries.GetBookBorrowsByUser;

public record GetBookBorrowsByUserQuery(string UserId) : IRequest<DataResponse<GetUserBookBorrowsByUserDto>>;