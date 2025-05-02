using OnlineLibraryProject.Domain.Abstractions;

namespace OnlineLibraryProject.Domain.Dtos.EntityDtos.BookRating;

public record TopRatingBooksDto(string BookId, string BookName, string AuthorName, string NumberOfPages, string ImageBase64, double Rating, int RatingCount, bool IsEbook, string EbookUrl) : EntityDTO;