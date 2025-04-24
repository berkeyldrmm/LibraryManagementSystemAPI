using MediatR;
using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.Book;
using OnlineLibraryProject.Domain.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibraryProject.Application.Features.BookFeatures.Commands.CreateBook
{
    public class CreateBookCommandHandler : BookHandler, IRequestHandler<CreateBookCommand, DataResponse<CreatedBookDto>>
    {
        public CreateBookCommandHandler(IBookService bookService) : base(bookService)
        {
        }

        public async Task<DataResponse<CreatedBookDto>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            return await _bookService.CreateBook(request, cancellationToken);
        }
    }
}
