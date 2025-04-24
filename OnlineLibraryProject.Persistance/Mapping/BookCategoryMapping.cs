using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Book;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookCategory;
using OnlineLibraryProject.Domain.Entities;

namespace OnlineLibraryProject.Persistance.Mapping;

public static class BookCategoryMapping
{
    public static async Task<IEnumerable<BookCategoryListDto>> ToBookCategoryListDto(this IQueryable<BookCategory> bookCategoryEntity)
    {
        return await bookCategoryEntity.Select(d => new BookCategoryListDto(d.Book.Id,
            d.Book.Name,
            d.Book.ImageBase64,
            d.Book.AuthorName,
            d.Book.NumberOfPages,
            d.Book.IsEbook,
            d.Category.Name)).ToListAsync();
    }

    public static async Task<GetBookWithCategoryDto> ToGetBookWithCategoriesDto(this IQueryable<BookCategory> bookCategoryEntity)
    {
        var first = await bookCategoryEntity.FirstOrDefaultAsync();
        var dto = first != null ? new GetBookWithCategoryDto(first.Book.Id,
            first.Book.Name,
            first.Book.ImageBase64,
            first.Book.AuthorName,
            first.Book.NumberOfPages,
            first.Book.IsEbook,
            await bookCategoryEntity.Select(b => b.Category.Name).ToListAsync()) : null;

        return dto;
    }

    public static async Task<GetBooksByCategoryDto> ToGetBooksByCategoryDto(this IQueryable<BookCategory> bookCategoryEntity)
    {
        return new GetBooksByCategoryDto(await bookCategoryEntity.Select(b => new BookListDto(
            b.Book.Name,
            b.Book.ImageBase64,
            b.Book.AuthorName,
            b.Book.NumberOfPages,
            b.Book.IsEbook,
            b.Book.EBookUrl)
        { Id = b.BookId }).ToListAsync(), bookCategoryEntity.First().Category.Name);
    }
}
