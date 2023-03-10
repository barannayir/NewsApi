using AutoMapper;
using Business.Concrete;
using Business.Interfaces;
using Business.Mapper;
using Core.Services.Logs;
using Core.Services.Logs.Interfaces;
using Core.Services.Security.Jwt;
using Core.Services.Security.Jwt.Interfaces;
using DataAccess.Data;
using DataAccess.Interfaces;
using DataAccess.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddAutoMapper(typeof(GeneralMapper));
var config = new MapperConfiguration(cfg => cfg.AddProfile<GeneralMapper>());
var mapper = new Mapper(config);

builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();




builder.Services.AddScoped<ISecurityService, SecurityService>();
builder.Services.AddScoped<ILoggerService, FileLoggerService>();
builder.Services.AddScoped<IJwtService, JwtService>();

builder.Services.AddScoped<NewsDbContext>();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));

var jwtOptions = builder.Configuration.GetSection("JwtOptions").Get<JwtOptions>();
var tokenConfigurations = new TokenConfigurations(jwtOptions.SecretKey);
builder.Services.AddSingleton(tokenConfigurations);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = jwtOptions.Issuer,
        ValidateAudience = true,
        ValidAudience = jwtOptions.Audience,
        IssuerSigningKey = tokenConfigurations.SecurityKey,
        ValidateLifetime = true,
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<NewsDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers()
        .RequireAuthorization();
});

app.MapControllers();

app.Run();
