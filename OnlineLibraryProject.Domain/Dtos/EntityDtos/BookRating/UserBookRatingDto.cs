using OnlineLibraryProject.Domain.Abstractions;

namespace OnlineLibraryProject.Domain.Dtos.EntityDtos.BookRating;

public record UserBookRatingDto(int Star) : EntityDTO;