using DesafioDotNetBaltaIO.Application.DTOs;
using DesafioDotNetBaltaIO.Application.Interfaces;
using DesafioDotNetBaltaIO.Application.Mappings;
using DesafioDotNetBaltaIO.Application.Services;
using DesafioDotNetBaltaIO.Domain.Entities;
using DesafioDotNetBaltaIO.Domain.Interfaces;
using DesafioDotNetBaltaIO.Infrastructure.Context;
using DesafioDotNetBaltaIO.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

#region Configure services

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Minimal API Sample",
        Description = "",
        License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Insert the JWT token: Bearer {your token}",
        Name = "Authorization",
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// Dependency Injection

// Repositories
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
// Services
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddTransient<IUserService, UserService>();

// Configure AutoMapper
builder.Services.AddAutoMapper(typeof(LocationMappingProfile));

// Configure context
builder.Services.AddDbContext<DesafioDotNetBaltaIOContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerDocker")));

var app = builder.Build();

#endregion

#region Configure pipelines

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

MapActionsLogin(app);
MapActionsLocations(app);

app.Run();

#endregion

#region Enpoints Login

void MapActionsLogin(WebApplication app)
{
    app.MapPost("/login", [AllowAnonymous] async (
        UserDTO user, IUserService service) =>
    {
        if (user == null)
            return Results.BadRequest("User is required");

        if (!MiniValidator.TryValidate(loginUser, out var errors))
            return Results.ValidationProblem(errors);

        var result = await signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

        if (result.IsLockedOut)
            return Results.BadRequest("Blocked user");

        if (!result.Succeeded)
            return Results.BadRequest("Invalid user or password");

        var jwt = new JwtBuilder()
            .WithUserManager(userManager)
            .WithJwtSettings(appJwtSettings.Value)
            .WithEmail(loginUser.Email)
            .WithJwtClaims()
            .WithUserClaims()
            .WithUserRoles()
            .BuildUserResponse();

        return Results.Ok(jwt);
    })
        .ProducesValidationProblem()
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .WithName("UserLogin")
        .WithTags("User");

    //app.MapPost("/register", [AllowAnonymous] async (
    //    UserManager<IdentityUser> userManager,
    //    IOptions<AppJwtSettings> appJwtSettings,
    //    RegisterUser registerUser) =>
    //{
    //    if (registerUser == null)
    //        return Results.BadRequest("User is required");

    //    if (!MiniValidator.TryValidate(registerUser, out var errors))
    //        return Results.ValidationProblem(errors);

    //    var user = new IdentityUser
    //    {
    //        UserName = registerUser.Email,
    //        Email = registerUser.Email,
    //        EmailConfirmed = true
    //    };

    //    var result = await userManager.CreateAsync(user, registerUser.Password);

    //    if (!result.Succeeded)
    //        return Results.BadRequest(result.Errors);

    //    var jwt = new JwtBuilder()
    //        .WithUserManager(userManager)
    //        .WithJwtSettings(appJwtSettings.Value)
    //        .WithEmail(user.Email)
    //        .WithJwtClaims()
    //        .WithUserClaims()
    //        .WithUserRoles()
    //        .BuildUserResponse();

    //    return Results.Ok(jwt);
    //})
    //    .ProducesValidationProblem()
    //    .Produces(StatusCodes.Status200OK)
    //    .Produces(StatusCodes.Status400BadRequest)
    //    .WithName("UserRegister")
    //    .WithTags("User");


}

#endregion

#region Endpoints Locations

void MapActionsLocations(WebApplication app)
{

    app.MapGet("/locations", async (ILocationService service) =>
            await service.GetLocationsAsync())                
            .Produces<Location>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithName("GetLocations")
            .WithTags("Locations");

    //app.MapGet("/locations-by-city/{city}", async (
    //        Guid id, MinimalContextDb context) =>

    //        await context.Customers.FindAsync(id)
    //            is Customer location
    //                ? Results.Ok(location)
    //                : Results.NotFound())
    //        .Produces<Customer>(StatusCodes.Status200OK)
    //        .Produces(StatusCodes.Status404NotFound)
    //        .WithName("GetLocationByCity")
    //        .WithTags("Locations");

    //app.MapGet("/locations-by-state/{state}", async (
    //        Guid id, MinimalContextDb context) =>

    //        await context.Customers.FindAsync(id)
    //            is Customer customer
    //                ? Results.Ok(customer)
    //                : Results.NotFound())
    //        .Produces<Customer>(StatusCodes.Status200OK)
    //        .Produces(StatusCodes.Status404NotFound)
    //        .WithName("GetLocationByState")
    //        .WithTags("Locations");

    //app.MapGet("/locations-by-ibge/{ibge}", [AllowAnonymous] async (
    //        Guid id, MinimalContextDb context) =>

    //        await context.Customers.FindAsync(id)
    //            is Customer customer
    //                ? Results.Ok(customer)
    //                : Results.NotFound())
    //        .Produces<Customer>(StatusCodes.Status200OK)
    //        .Produces(StatusCodes.Status404NotFound)
    //        .WithName("GetLocationByIbge")
    //        .WithTags("Customer");

}
#endregion