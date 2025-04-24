using AutoMapper;
using OnlineLibraryProject.Domain.Entities;
using OnlineLibraryProject.Domain.Repositories;
using OnlineLibraryProject.Persistance.Context;

namespace OnlineLibraryProject.Persistance.Repository;

public class ErrorLogRepository : GenericRepository<ErrorLog>, IErrorLogRepository
{
    public ErrorLogRepository(OnlineLibraryDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
