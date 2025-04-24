using OnlineLibraryProject.Domain.Abstractions;

namespace OnlineLibraryProject.Domain.Dtos.EntityDtos.BookRating;

public record BookRatingsDto(string BookId, IEnumerable<BookRatingDto> Ratings, string AverageRating) : EntityDTO;