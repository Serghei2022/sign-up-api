using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using sign_up_api.DbContexts;
using sign_up_api.Entities;
using sign_up_api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SignUpDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SignUpDBConnectionString")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.MapGet("/industries", async (SignUpDbContext signUpDbContext) =>
{
    return await signUpDbContext.Industries.ToListAsync();
});

app.MapGet("/industries/{industryId:guid}", async (SignUpDbContext signUpDbContext,
    Guid industryId) => {
        return await signUpDbContext.Industries
            .FirstOrDefaultAsync(i => i.Id == industryId);
    }
);

app.MapGet("/industries/{industryName}", async (SignUpDbContext signUpDbContext,
    string industryName) => {
        return await signUpDbContext.Industries
            .FirstOrDefaultAsync(i => i.Name == industryName);
    }
);

app.MapGet("/companies/{companyId:guid}", async Task<Results<NotFound, Ok<CompanyDto>>> (SignUpDbContext signUpDbContext,
    IMapper mapper,
    Guid companyId) =>
    {
        var companyEntity = await signUpDbContext.Companies
            .FirstOrDefaultAsync(c => c.Id == companyId);

        if (companyEntity == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(mapper.Map<CompanyDto>(companyEntity));
    }).WithName("GetCompany");

// app.MapPost("/companies", async Task<IResult> (
app.MapPost("/companies", async Task<CreatedAtRoute<CompanyDto>> (
    SignUpDbContext signUpDbContext,
    IMapper mapper,
    CompanyForCreationDto companyForCreationDto) =>
{
    var companyEntity = mapper.Map<Company>(companyForCreationDto);

    // try
    // {
        signUpDbContext.Add(companyEntity);
        await signUpDbContext.SaveChangesAsync();

        var companyToReturn = mapper.Map<CompanyDto>(companyEntity);

        return TypedResults.CreatedAtRoute(
            companyToReturn,
            "GetCompany",
            new {companyId = companyToReturn.Id});
    // }
    // catch (DbUpdateException ex) when (ex.InnerException is SqliteException sqlEx && sqlEx.SqliteErrorCode == 19)
    // {
    //     //19 is the SQLite constraint violation error code
    //     return Results.BadRequest("A company with this name already exists.");
    // }
    // catch
    // {
    //     return Results.Problem("An error occurred while creating the company.");
    // }
});

app.MapGet("/users/{userId:guid}", async Task<Results<NotFound, Ok<UserDto>>> (SignUpDbContext signUpDbContext,
    IMapper mapper,
    Guid userId) =>
    {
        var userEntity = await signUpDbContext.Users
            .FirstOrDefaultAsync(u => u.Id == userId);

        if (userEntity == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(mapper.Map<UserDto>(userEntity));
    }).WithName("GetUser");

app.MapGet("/users/{userName}", async (SignUpDbContext signUpDbContext,
    string userName) => {
        return await signUpDbContext.Users
            .FirstOrDefaultAsync(i => i.UserName == userName);
    }
);

app.MapPost("/users", async Task<CreatedAtRoute<UserDto>> (
    SignUpDbContext signUpDbContext,
    IMapper mapper,
    UserForCreationDto userForCreationDto) =>
{
    var userEntity = mapper.Map<User>(userForCreationDto);
    signUpDbContext.Add(userEntity);
    await signUpDbContext.SaveChangesAsync();

    var userToReturn = mapper.Map<UserDto>(userEntity);

    return TypedResults.CreatedAtRoute(
        userToReturn,
        "GetUser",
        new {userId = userToReturn.Id});
});

app.Run();
