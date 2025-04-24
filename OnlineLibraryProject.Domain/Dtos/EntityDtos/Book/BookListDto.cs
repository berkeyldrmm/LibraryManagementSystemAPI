using OnlineLibraryProject.Domain.Abstractions;

namespace OnlineLibraryProject.Domain.Dtos.EntityDtos.Book;

public record BookListDto(string Name,
                          string ImageBase64,
                          string AuthorName,
                          string NumberOfPages,
                          bool IsEbook,
                          string EBookUrl) : EntityDTO<string>;
