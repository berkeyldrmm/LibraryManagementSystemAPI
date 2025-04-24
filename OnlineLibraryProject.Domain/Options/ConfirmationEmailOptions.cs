using OnlineLibraryProject.Domain.Abstractions;

namespace OnlineLibraryProject.Domain.Options;

public class ConfirmationEmailOptions : EmailOptions
{
    public string ConfirmEmailBaseLink { get; set; }
}
