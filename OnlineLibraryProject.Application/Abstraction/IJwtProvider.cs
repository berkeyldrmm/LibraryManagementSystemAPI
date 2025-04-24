using OnlineLibraryProject.Application.Features.AuthFeatures.Commands.Login;
using OnlineLibraryProject.Domain.Entities;

namespace OnlineLibraryProject.Application.Abstraction;

public interface IJwtProvider
{
    Task<LoginCommandResponse> CreateToken(User user);
}
