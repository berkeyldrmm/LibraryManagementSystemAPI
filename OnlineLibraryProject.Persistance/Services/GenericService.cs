using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Abstractions;
using OnlineLibraryProject.Domain.Dtos.Responses;
using OnlineLibraryProject.Domain.Repositories;
using System.Reflection;
using System.Security.Claims;

namespace OnlineLibraryProject.Persistance.Services;

public class GenericService<T, TListDto, Dto, PostCommand, TRepository>
    : IGenericService<T, TListDto, Dto, PostCommand>
    where T : Entity
    where TListDto : EntityDTO
    where Dto : EntityDTO
    where TRepository : IGenericRepository<T>
{
    protected readonly TRepository _repository;
    protected readonly IServiceProvider ServiceProvider;
    protected readonly IMapper _mapper;
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IHttpContextAccessor _httpContextAccessor;
    public GenericService(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
        _repository = (TRepository)ServiceProvider.GetService(typeof(TRepository));
        _mapper = (IMapper)ServiceProvider.GetService(typeof(IMapper));
        _unitOfWork = (IUnitOfWork)ServiceProvider.GetService(typeof(IUnitOfWork));
        _httpContextAccessor = (IHttpContextAccessor)ServiceProvider.GetService(typeof(IHttpContextAccessor));
    }

    public async Task<MessageResponse> Create(PostCommand dto, CancellationToken cancellationToken)
    {
        T entity = _mapper.Map<T>(dto);

        var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!string.IsNullOrEmpty(userId))
        {
            var userIdProp = typeof(T).GetProperty("UserId", BindingFlags.Public | BindingFlags.Instance);
            if (userIdProp != null && userIdProp.CanWrite)
            {
                var convertedId = Convert.ChangeType(userId, userIdProp.PropertyType);
                userIdProp.SetValue(entity, convertedId);
            }
        }

        _ = await _repository.AddAsync(entity, cancellationToken);
        _ = await _unitOfWork.SaveChangesAsync();

        return new();
    }

    public async Task<MessageResponse> Delete(string id, CancellationToken cancellationToken)
    {
        T entity = await _repository.GetByIdAsync(id);
        if (entity == null)
            throw new Exception("Entity not found");

        var userIdFromToken = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!string.IsNullOrEmpty(userIdFromToken))
        {
            var userIdProp = entity.GetType().GetProperty("UserId", BindingFlags.Public | BindingFlags.Instance);
            if (userIdProp != null && userIdProp.CanRead)
            {
                var value = userIdProp.GetValue(entity)?.ToString();
                if (value != userIdFromToken)
                    throw new UnauthorizedAccessException("You do not have a permission to delete this entity.");
            }
        }
        _ = _repository.DeleteAsync(entity);
        _ = await _unitOfWork.SaveChangesAsync();

        return new();
    }

    public async Task<DataResponse<Dto>> GetByIdAsync(string id)
    {
        Dto data = await _repository.GetOneAsync<Dto>(id);
        return new DataResponse<Dto>(data);
    }

    public async Task<ListDataResponse<TListDto>> GetList()
    {
        List<TListDto> data = await _repository.GetAll<TListDto>().ToListAsync();
        return new ListDataResponse<TListDto>(data);
    }
}
