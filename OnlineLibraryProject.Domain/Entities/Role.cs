using Microsoft.AspNetCore.Identity;

namespace OnlineLibraryProject.Domain.Entities;

public class Role : IdentityRole<string>
{
    public Role()
    {
        Id = Guid.NewGuid().ToString();
    }
}
