using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace OnlineLibraryProject.WebApi.OptionsSetup
{
    public class IdentityOptionsSetup : IPostConfigureOptions<IdentityOptions>
    {
        public void PostConfigure(string name, IdentityOptions options)
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
        }
    }
}
