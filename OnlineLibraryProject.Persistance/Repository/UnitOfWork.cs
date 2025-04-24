using OnlineLibraryProject.Domain.Repositories;
using OnlineLibraryProject.Persistance.Context;

namespace OnlineLibraryProject.Persistance.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly OnlineLibraryDbContext _context;

    public UnitOfWork(OnlineLibraryDbContext context)
    {
        _context = context;
    }

    public void ClearTracking()
    {
        _context.ChangeTracker.Clear();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
