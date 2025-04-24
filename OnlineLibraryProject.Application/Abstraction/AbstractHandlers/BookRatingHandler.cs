using OnlineLibraryProject.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibraryProject.Application.Abstraction.AbstractHandlers
{
    public abstract class BookRatingHandler
    {
        public IBookRatingService _bookRatingService { get; set; }

        protected BookRatingHandler(IBookRatingService bookRatingService)
        {
            _bookRatingService = bookRatingService;
        }
    }
}
