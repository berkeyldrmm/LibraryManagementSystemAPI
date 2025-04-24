using OnlineLibraryProject.Application.Abstraction.AbstractHandlers;
using OnlineLibraryProject.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.AuthFeatures.Commands.Register
{
    public sealed class RegisterCommandHandler : AuthHandler, IRequestHandler<RegisterCommand, MessageResponse>
    {
        public RegisterCommandHandler(IAuthService authService) : base(authService)
        {
        }

        public async Task<MessageResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authService.Register(request);
            return new MessageResponse("User has been saved successfully!");
        }
    }
}
