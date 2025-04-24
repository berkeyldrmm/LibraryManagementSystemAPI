namespace OnlineLibraryProject.Domain.Repositories;

public interface IUnitOfWork
{
    public Task<int> SaveChangesAsync();
    public void ClearTracking();
}
