using OnlineLibraryProject.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineLibraryProject.Domain.Entities;

public class UserBookBorrow : Entity
{
    [ForeignKey("User")]
    public string UserId { get; set; }
    public User User { get; set; }
    [ForeignKey("Book")]
    public string BookId { get; set; }
    public Book Book { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime BorrowEndDate { get; set; }
    public bool Status { get; set; }
}
