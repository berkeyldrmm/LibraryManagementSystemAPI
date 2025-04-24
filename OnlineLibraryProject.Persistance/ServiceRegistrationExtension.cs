using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Repositories;
using OnlineLibraryProject.Persistance.Repository;
using OnlineLibraryProject.Persistance.Services;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineLibraryProject.Persistance;

public static class ServiceRegistrationExtension
{
    public static IServiceCollection RegisterPersistanceServices(this IServiceCollection services)
    {
        services.AddScoped<IErrorLogRepository, ErrorLogRepository>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        services.AddScoped<IBookCategoryRepository, BookCategoryRepository>();
        services.AddScoped<IBookRatingRepository, BookRatingRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IUserBookBorrowRepository, UserBookBorrowRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IBookCategoryService, BookCategoryService>();
        services.AddScoped<IBookRatingService, BookRatingService>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IUserBookBorrowService, UserBookBorrowService>();
        services.AddScoped<IUserRoleService, UserRoleService>();

        return services;
    }
}
