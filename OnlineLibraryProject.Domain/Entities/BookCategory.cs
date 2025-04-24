using OnlineLibraryProject.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibraryProject.Domain.Entities
{
    public class BookCategory : Entity
    {
        [ForeignKey("Book")]
        public string BookId { get; set; }
        public Book Book { get; set; }
        [ForeignKey("Category")]
        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
