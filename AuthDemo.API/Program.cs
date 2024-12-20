using AuthDemo.Middlewares;
using AuthDemo.Constants;
using AuthDemo.Domain;
using AuthDemo.IManagers;
using AuthDemo.Managers;
using AuthDemo.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using AuthDemo.Filters;
using AuthDemo.API.Config;
using System.Console;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "test",
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

WriteLine("this is just a text");

builder.Services.AddSwaggerGen(options =>
{
    options.DocumentFilter<SwaggerDocumentFilter>();
    // options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    // {
    //     In = ParameterLocation.Header,
    //     Name = "Authorization",
    //     Description = "Please enter your bearer token",
    //     BearerFormat = "JWT",
    //     Type = SecuritySchemeType.Http,
    //     Scheme = "bearer"
    // });

    // options.AddSecurityRequirement(new OpenApiSecurityRequirement
    // {
    //     {
    //         new OpenApiSecurityScheme
    //         {
    //             Reference = new OpenApiReference
    //             {
    //                 Type=ReferenceType.SecurityScheme,
    //                 Id="Bearer"
    //             }
    //         },
    //         Array.Empty<string>()
    //     }
    // });
});


builder.Services.AddDbContext<AuthDemoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(DbConstants.DbConnectionString)));

builder.Services.AddIdentityCore<ApplicationUser>()
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<AuthDemoContext>()
    .AddApiEndpoints();

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);

// builder.Services.Configure<RouteConfig>(builder.Configuration.GetSection("RouteConfig"));
builder.Services.AddAuthorization();
builder.Services.AddAuthorizationBuilder();

//custom services
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddScoped<IUserManager, UserManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<RouteProtectionMiddleware>();

app.UseCors("test");

app.UseAuthentication();
app.UseAuthorization();

app.MapGroup("auth").MapIdentityApi<ApplicationUser>();
app.MapControllers();


app.Run();

public partial class Program;
