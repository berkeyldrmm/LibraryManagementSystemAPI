using MediatR;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Category;
using OnlineLibraryProject.Domain.Dtos.Requests;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.CategoryFeatures.Queries.GetAllCategoriesPaged;

public class GetAllCategoriesPagedQuery : PageRequest, IRequest<PagedListDataResponse<CategoryListDto>>
{
}
