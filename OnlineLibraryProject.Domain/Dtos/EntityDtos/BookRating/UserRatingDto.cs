using OnlineLibraryProject.Domain.Abstractions;

namespace OnlineLibraryProject.Domain.Dtos.EntityDtos.BookRating;

public record UserRatingDto(string BookId, string BookName, string Rating) : EntityDTO<string>;
