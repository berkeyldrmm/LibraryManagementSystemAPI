using OnlineLibraryProject.Application.Behaviors;
using OnlineLibraryProject.Domain;
using OnlineLibraryProject.Domain.Entities;
using OnlineLibraryProject.Infrastructure;
using OnlineLibraryProject.Persistance;
using OnlineLibraryProject.Persistance.Context;
using OnlineLibraryProject.WebApi.Middleware;
using OnlineLibraryProject.WebApi.OptionsSetup;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddApplicationPart(typeof(OnlineLibraryProject.Presentation.AssemblyReference).Assembly);

builder.Services.AddOpenApi();

builder.Services.AddTransient<ExceptionMiddleware>();

builder.Services.AddAutoMapper(typeof(OnlineLibraryProject.Persistance.AssemblyReference));

builder.Services.AddDbContext<OnlineLibraryDbContext>(o =>
    o.UseNpgsql(builder.Configuration.GetConnectionString("ApplicationDb")));

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<OnlineLibraryDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureOptions<IdentityOptionsSetup>();

builder.Services.RegisterPersistanceServices();
builder.Services.RegisterInfrastructureServices();
builder.Services.RegisterDomainServices(builder.Configuration);

builder.Services.AddMediatR(c =>
    c.RegisterServicesFromAssembly(typeof(OnlineLibraryProject.Application.AssemblyReference).Assembly));

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddValidatorsFromAssembly(typeof(OnlineLibraryProject.Application.AssemblyReference).Assembly);

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin()
        .SetIsOriginAllowed(policy => true);
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(opt =>
    {
        opt.WithTitle("Scalar on Online Library App")
            .WithTheme(ScalarTheme.Mars)
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
            .WithPreferredScheme("Bearer");
    });
}

app.MiddlewareRegister();

app.UseCors();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
