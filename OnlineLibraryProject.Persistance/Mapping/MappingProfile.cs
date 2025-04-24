using AutoMapper;
using OnlineLibraryProject.Application.Features.AuthFeatures.Commands.Register;
using OnlineLibraryProject.Application.Features.BookCategoryFeatures.Command.CreateBookCategory;
using OnlineLibraryProject.Application.Features.BookCategoryFeatures.Command.DeleteBookCategory;
using OnlineLibraryProject.Application.Features.BookFeatures.Commands.CreateBook;
using OnlineLibraryProject.Application.Features.BookFeatures.Commands.UpdateBook;
using OnlineLibraryProject.Application.Features.BookRatingFeatures.Command.CreateBookRating;
using OnlineLibraryProject.Application.Features.BookRatingFeatures.Command.UpdateBookRating;
using OnlineLibraryProject.Application.Features.CategoryFeatures.Commands.CreateCategory;
using OnlineLibraryProject.Application.Features.CategoryFeatures.Commands.UpdateCategory;
using OnlineLibraryProject.Application.Features.CategoryFeatures.Queries.GetCategoryById;
using OnlineLibraryProject.Application.Features.RoleFeatures.Commands.CreateRole;
using OnlineLibraryProject.Application.Features.RoleFeatures.Commands.UpdateRole;
using OnlineLibraryProject.Application.Features.UserBookBorrowFeatures.Commands.CreateUserBookBorrow;
using OnlineLibraryProject.Application.Features.UserBookBorrowFeatures.Commands.DeleteUserBookBorrow;
using OnlineLibraryProject.Application.Features.UserBookBorrowFeatures.Commands.UpdateUserBookBorrow;
using OnlineLibraryProject.Application.Features.UserRoleFeatures.Commands.CreateUserRole;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Book;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookCategory;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Category;
using OnlineLibraryProject.Domain.Entities;

namespace OnlineLibraryProject.Persistance.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterCommand, User>().ReverseMap();

        CreateMap<CreateBookCategoryCommand, BookCategory>().ReverseMap();

        CreateMap<CreateBookCommand, Book>().ReverseMap();
        CreateMap<CreateBookCommand, BookDto>().ReverseMap();
        CreateMap<UpdateBookCommand, Book>().ReverseMap();
        CreateMap<Book, BookDto>().ReverseMap();
        CreateMap<Book, BookListDto>().ReverseMap();

        CreateMap<CreateBookCategoryCommand, BookCategory>().ReverseMap();
        CreateMap<DeleteBookCategoryCommand, BookCategory>().ReverseMap();
        CreateMap<BookCategoryDto, BookCategory>().ReverseMap();
        CreateMap<BookCategoryListDto, BookCategory>().ReverseMap();

        CreateMap<CreateBookRatingCommand, BookRating>().ReverseMap();

        CreateMap<CreateCategoryCommand, Category>().ReverseMap();
        CreateMap<CreateCategoryCommand, CategoryDto>().ReverseMap();
        CreateMap<UpdateCategoryCommand, Category>().ReverseMap();
        CreateMap<GetCategoryByIdQuery, CategoryDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Category, CategoryListDto>().ReverseMap();

        CreateMap<CreateRoleCommand, Role>().ReverseMap();

        CreateMap<CreateUserBookBorrowCommand, UserBookBorrow>().ReverseMap();

        CreateMap<CreateUserRoleCommand, UserRole>().ReverseMap();
    }
}
