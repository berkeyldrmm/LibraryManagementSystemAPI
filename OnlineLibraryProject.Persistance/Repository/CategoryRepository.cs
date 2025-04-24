using AutoMapper;
using OnlineLibraryProject.Domain.Entities;
using OnlineLibraryProject.Domain.Repositories;
using OnlineLibraryProject.Persistance.Context;

namespace OnlineLibraryProject.Persistance.Repository;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(OnlineLibraryDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
