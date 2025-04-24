using OnlineLibraryProject.Domain.Abstractions;

namespace OnlineLibraryProject.Domain.Dtos.EntityDtos.Book
{
    public record BookDto(string Id, string Name, string AuthorName, IEnumerable<string> Categories, string NumberOfPages, string Description, string ImageBase64, bool IsEbook, string EBookUrl) : EntityDTO;
}
