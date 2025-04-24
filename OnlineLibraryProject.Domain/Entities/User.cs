using OnlineLibraryProject.Domain.Abstractions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibraryProject.Domain.Entities
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string NameSurname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpires { get; set; }
        public IEnumerable<BookRating> BookRatings { get; set; }
        public IEnumerable<UserBookBorrow> BookBorrows { get; set; }
    }
}
