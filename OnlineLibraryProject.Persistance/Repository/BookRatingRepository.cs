using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OnlineLibraryProject.Domain.Dtos.EntityDtos.BookRating;
using OnlineLibraryProject.Domain.Entities;
using OnlineLibraryProject.Domain.Repositories;
using OnlineLibraryProject.Persistance.Context;
using System.Net;
using System.Security.Claims;

namespace OnlineLibraryProject.Persistance.Repository;

public class BookRatingRepository : GenericRepository<BookRating>, IBookRatingRepository
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public BookRatingRepository(OnlineLibraryDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, mapper)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public bool Any(string bookId)
    {
        string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Entity.Any(r => r.UserId == userId && r.BookId == bookId);
    }

    public IQueryable<BookRatingsDto> GetBookRatings(string bookId)
    {
        return Entity.Where(b => b.BookId == bookId).Include(b => b.User).Include(b => b.Book).Select(b => new BookRatingsDto(b.BookId, b.Book.Ratings.Select(b=>new BookRatingDto(b.UserId, b.User.UserName, b.Star)), b.Book.Ratings.Any() ? b.Book.Ratings.Average(br => (double)br.Star).ToString() : "0.0"));
    }

    public IQueryable<UserRatingsDto> GetBookRatingsByUser(string userId)
    {
        return Entity.Where(b => b.UserId == userId).Include(b => b.User).Include(b => b.Book).Select(b => new UserRatingsDto(b.UserId, b.User.UserName, b.User.BookRatings.Select(b => new UserRatingDto(b.BookId, b.Book.Name, b.Star.ToString())), b.Book.Ratings.Any() ? b.Book.Ratings.Average(br => (double)br.Star).ToString() : "0.0"));
    }

    public IQueryable<UserBookRatingDto> GetUserBookRating(string bookId)
    {
        string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Entity.Where(e => e.BookId == bookId).Where(e => e.UserId == userId).Select(e=> new UserBookRatingDto(e.Star));
    }
}
