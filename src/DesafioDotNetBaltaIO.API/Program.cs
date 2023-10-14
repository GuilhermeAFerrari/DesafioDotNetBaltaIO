using DesafioDotNetBaltaIO.Application.DTOs;
using DesafioDotNetBaltaIO.Application.Interfaces;
using DesafioDotNetBaltaIO.Application.Mappings;
using DesafioDotNetBaltaIO.Application.Services;
using DesafioDotNetBaltaIO.Domain.Entities;
using DesafioDotNetBaltaIO.Domain.Interfaces;
using DesafioDotNetBaltaIO.Infrastructure.Context;
using DesafioDotNetBaltaIO.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MiniValidation;

var builder = WebApplication.CreateBuilder(args);

#region Configure services

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Desafio DotNet Balta IO - Location",
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
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();

// Configure AutoMapper
builder.Services.AddAutoMapper(typeof(LocationMappingProfile));

//TODO: Configure context
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

    //app.MapPost("/login", [AllowAnonymous] async (
    //    SignInManager<IdentityUser> signInManager,
    //    UserManager<IdentityUser> userManager,
    //    IOptions<AppJwtSettings> appJwtSettings,
    //    LoginUser loginUser) =>
    //{
    //    if (loginUser == null)
    //        return Results.BadRequest("User is required");

    //    if (!MiniValidator.TryValidate(loginUser, out var errors))
    //        return Results.ValidationProblem(errors);

    //    var result = await signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

    //    if (result.IsLockedOut)
    //        return Results.BadRequest("Blocked user");

    //    if (!result.Succeeded)
    //        return Results.BadRequest("Invalid user or password");

    //    var jwt = new JwtBuilder()
    //        .WithUserManager(userManager)
    //        .WithJwtSettings(appJwtSettings.Value)
    //        .WithEmail(loginUser.Email)
    //        .WithJwtClaims()
    //        .WithUserClaims()
    //        .WithUserRoles()
    //        .BuildUserResponse();

    //    return Results.Ok(jwt);
    //})
    //    .ProducesValidationProblem()
    //    .Produces(StatusCodes.Status200OK)
    //    .Produces(StatusCodes.Status400BadRequest)
    //    .WithName("UserLogin")
    //    .WithTags("User");
}

#endregion

#region Endpoints Locations

void MapActionsLocations(WebApplication app)
{
    app.MapGet("/locations", async (ILocationService service) =>
            await service.GetAsync())                
            .Produces<IEnumerable<LocationDTO>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithName("GetLocations")
            .WithTags("Location");

    app.MapGet("/locations/city/{city}", async (
            string city, ILocationService service) =>

            await service.GetByCityAsync(city)
                is LocationDTO location
                    ? Results.Ok(location)
                    : Results.NotFound())
            .Produces<LocationDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithName("GetLocationByCity")
            .WithTags("Location");

    app.MapGet("/locations/state/{state}", async (
            string state, ILocationService service) =>

            await service.GetByStateAsync(state)
                is LocationDTO location
                    ? Results.Ok(location)
                    : Results.NotFound())
            .Produces<LocationDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithName("GetLocationByState")
            .WithTags("Location");

    app.MapGet("/locations/ibge/{ibge}", async (
            string ibge, ILocationService service) =>

            await service.GetByIbgeAsync(ibge)
                is LocationDTO location
                    ? Results.Ok(location)
                    : Results.NotFound())
            .Produces<LocationDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithName("GetLocationByIbge")
            .WithTags("Location");

    app.MapPost("/location", async (LocationDTO location, ILocationService service) =>
    {
        if (!MiniValidator.TryValidate(location, out var errors))
            return Results.ValidationProblem(errors);

        var result = await service.AddAsync(location);

        return result is LocationDTO
            ? Results.CreatedAtRoute("GetLocationByIbge", new { ibge = location.Id }, location)
            : Results.BadRequest("An error ocurred while saving the record");
    })
        .ProducesValidationProblem()
        .Produces<LocationDTO>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest)
        .WithName("PostLocation")
        .WithTags("Location");


    //app.MapPut("/customer/{id}", [Authorize] async (
    //    Guid id, MinimalContextDb context, Customer customer) =>
    //{
    //    var customerFromDatabase = await context.Customers.AsNoTracking()
    //        .FirstOrDefaultAsync(x => x.Id == id);
    //    if (customerFromDatabase == null) return Results.NotFound();

    //    if (!MiniValidator.TryValidate(customer, out var errors))
    //        return Results.ValidationProblem(errors);

    //    context.Customers.Update(customer);
    //    var result = await context.SaveChangesAsync();

    //    return result > 0
    //        ? Results.NoContent()
    //        : Results.BadRequest("An error ocurred while saving the record");
    //})
    //    .ProducesValidationProblem()
    //    .Produces(StatusCodes.Status404NotFound)
    //    .Produces(StatusCodes.Status204NoContent)
    //    .Produces(StatusCodes.Status400BadRequest)
    //    .WithName("PutCustomer")
    //    .WithTags("Customer");

    //app.MapDelete("/customer/{id}", [Authorize] async (
    //    Guid id, MinimalContextDb context) =>
    //{
    //    var customerFromDatabase = await context.Customers.FindAsync(id);
    //    if (customerFromDatabase == null) return Results.NotFound();

    //    context.Customers.Remove(customerFromDatabase);
    //    var result = await context.SaveChangesAsync();

    //    return result > 0
    //        ? Results.NoContent()
    //        : Results.BadRequest("An error ocurred while saving the record");
    //})
    //    .RequireAuthorization("DeleteCustomer")
    //    .Produces(StatusCodes.Status404NotFound)
    //    .Produces(StatusCodes.Status204NoContent)
    //    .Produces(StatusCodes.Status400BadRequest)
    //    .WithName("DeleteCustomer")
    //    .WithTags("Customer");
}

#endregion