using OnlineLibraryProject.Application.Services;

namespace OnlineLibraryProject.Application.Abstraction.AbstractHandlers;

public abstract class UserBookBorrowHandler
{
    public IUserBookBorrowService _userBookBorrowService { get; set; }

    protected UserBookBorrowHandler(IUserBookBorrowService userBookBorrowService)
    {
        _userBookBorrowService = userBookBorrowService;
    }
}
