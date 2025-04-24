using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLibraryProject.Domain.Dtos.Responses;

namespace OnlineLibraryProject.Application.Features.AuthFeatures.Commands.ConfirmEmail
{
    public sealed record ConfirmEmailCommand(
        string userId,
        string confirmationToken) : IRequest<MessageResponse>;
}
