using FluentValidation;
using OnlineLibraryProject.Application.Features.BookRatingFeatures.Command.CreateBookRating;
using OnlineLibraryProject.Domain.Repositories;

namespace OnlineLibraryProject.Application.Features.BookRatingFeatures.Commands.CreateBookRating;

public class CreateBookRatingCommandValidator : AbstractValidator<CreateBookRatingCommand>
{
    private readonly IBookRatingRepository _bookRatingRepository;
    public CreateBookRatingCommandValidator(IBookRatingRepository bookRatingRepository)
    {
        _bookRatingRepository = bookRatingRepository;

        RuleFor(e => e)
            .Must(Exists).WithMessage("You have already rated this book");
    }

    private bool Exists(CreateBookRatingCommand dto)
    {
        return !_bookRatingRepository.Any(dto.BookId);
    }
}
