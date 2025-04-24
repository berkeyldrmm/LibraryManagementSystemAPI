using MediatR;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Category;
using OnlineLibraryProject.Domain.Dtos.Requests;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.CategoryFeatures.Queries.GetCategoriesByFiltersPaged;

public class GetCategoriesByFiltersPagedQuery : PageRequest, IRequest<PagedListDataResponse<CategoryListDto>>
{
    public string Search { get; set; }
}