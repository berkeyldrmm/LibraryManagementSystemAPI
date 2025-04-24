using OnlineLibraryProject.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibraryProject.Domain.Entities
{
    public class BookRating : Entity
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Book")]
        public string BookId { get; set; }
        public Book Book { get; set; }
        public int Star { get; set; }
    }
}
