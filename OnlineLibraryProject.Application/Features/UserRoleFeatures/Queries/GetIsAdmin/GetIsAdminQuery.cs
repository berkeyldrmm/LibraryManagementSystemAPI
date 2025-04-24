using MediatR;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.UserRole;

namespace OnlineLibraryProject.Application.Features.UserRoleFeatures.Queries.GetIsAdmin;

public record GetIsAdminQuery() : IRequest<IsAdminDto>;