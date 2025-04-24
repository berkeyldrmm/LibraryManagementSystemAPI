using OnlineLibraryProject.Domain.Abstractions;
using OnlineLibraryProject.Domain.Dtos.Requests;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Services;

public interface IGenericService<T, TListDto, Dto, PostCommand>
    where T : Entity
    where TListDto : EntityDTO
    where Dto : EntityDTO
{
    Task<ListDataResponse<TListDto>> GetList();
    Task<DataResponse<Dto>> GetByIdAsync(string id);
    Task<MessageResponse> Create(PostCommand dto, CancellationToken cancellationToken);
    Task<MessageResponse> Delete(string id, CancellationToken cancellationToken);
}

public interface IUpdateable<PutCommand>
{
    Task<MessageResponse> Update(PutCommand dto);
}

public interface IFilter<TListDto, FilterQuery> where TListDto : EntityDTO
{
    Task<ListDataResponse<TListDto>> GetByFilters(FilterQuery dto);
}

public interface IPaged<TListDto, FilterQuery>
    where TListDto : EntityDTO
    where FilterQuery : PageRequest
{
    Task<PagedListDataResponse<TListDto>> GetAllPaged(PageRequest request);
    Task<PagedListDataResponse<TListDto>> GetPagedByFilters(FilterQuery dto);
}