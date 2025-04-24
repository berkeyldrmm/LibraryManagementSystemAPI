using OnlineLibraryProject.Domain.Abstractions;
using System.Linq.Expressions;

namespace OnlineLibraryProject.Domain.Repositories;

public interface IGenericRepository<T> where T : Entity
{
    Task<T> GetByIdAsync(string id);
    IQueryable<TDto> GetAll<TDto>() where TDto : EntityDTO;
    IQueryable<TDto> GetByFilters<TDto>(IEnumerable<Expression<Func<T, bool>>> expressions) where TDto : EntityDTO;
    Task<TDto> GetOneAsync<TDto>(string id);
    Task<bool> AddAsync(T entity, CancellationToken cancellationToken);
    Task<bool> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
    bool Update(T entity);
    bool DeleteAsync(T entity);
}
