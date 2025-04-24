using OnlineLibraryProject.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibraryProject.Application.Abstraction.AbstractHandlers
{
    public abstract class BookHandler
    {
        public IBookService _bookService;

        protected BookHandler(IBookService bookService)
        {
            _bookService = bookService;
        }
    }
}
