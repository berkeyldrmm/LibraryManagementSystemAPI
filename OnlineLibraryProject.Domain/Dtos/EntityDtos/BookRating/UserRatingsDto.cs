using OnlineLibraryProject.Domain.Abstractions;

namespace OnlineLibraryProject.Domain.Dtos.EntityDtos.BookRating;

public record UserRatingsDto(string UserId, string Username, IEnumerable<UserRatingDto> Ratings, string AverageRating) : EntityDTO;