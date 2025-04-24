using OnlineLibraryProject.Domain.Abstractions;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Book;

namespace OnlineLibraryProject.Domain.Dtos.EntityDtos.BookCategory;

public record GetBooksByCategoryDto(IEnumerable<BookListDto> Books, string Category) : EntityDTO;