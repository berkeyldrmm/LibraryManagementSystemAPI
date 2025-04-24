using OnlineLibraryProject.Domain.Abstractions;

namespace OnlineLibraryProject.Domain.Dtos.EntityDtos.BookRating;

public record BookRatingDto(string UserId, string UserName, int Star) : EntityDTO;
