using OnlineLibraryProject.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibraryProject.Domain.Entities
{
    public class Book : Entity
    {
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public int Stock { get; set; }
        public string NumberOfPages { get; set; }
        public string Description { get; set; }
        public bool IsEbook { get; set; }
        public string? EBookUrl { get; set; }
        public string ImageBase64 { get; set; }
        public IEnumerable<BookRating> Ratings { get; set; }
        public IEnumerable<BookCategory> Categories { get; set; }
        public IEnumerable<UserBookBorrow> UserBookBorrows { get; set; }
    }
}
