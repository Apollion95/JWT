using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using JWT.Controllers;
using JWT.DTO.Validator;
using JWT.Interfaces;
using JWT.Middlwares;
using JWT.Repository;
using JWT.Service;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.

services.AddControllers()
                .AddFluentValidation( x =>x.RegisterValidatorsFromAssemblyContaining<TestUserDtoValidator>())
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<UpdateProductDtoValidator>());

services.AddEndpointsApiExplorer();
services.AddAuthentication();

services.AddAuthentication(opt =>
    {
        opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidIssuer = "test",
            ClockSkew = TimeSpan.FromMinutes(0),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("w+1alOGke7bSPTgeMVlDXS5FRg3jcjRxkBtG0u3NrOo="))
        };
    });



services.AddSingleton<IProductsRepository, ProductsInMemoryReposiotry>();
services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IUserService, UserService>();




var provider = services.BuildServiceProvider();
var controller = provider.GetService<ProductsController>();
var controller2 = provider.GetService<ProductsController>();
var controller3 = provider.GetService<ProductsController>();


var app = builder.Build();




// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

app.UseAuthentication();
app.UseAuthorization();
//app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();

app.Run();
