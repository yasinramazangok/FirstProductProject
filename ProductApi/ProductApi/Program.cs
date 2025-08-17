using Microsoft.EntityFrameworkCore;
using ProductApi.API.Middlewares;
using ProductApi.BusinessLayer.Abstracts;
using ProductApi.BusinessLayer.Concretes;
using ProductApi.DataAccessLayer.Abstracts;
using ProductApi.DataAccessLayer.Concretes;
using ProductApi.DataAccessLayer.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Registering the Product repository and service with dependency injection
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

// CORS configuration is commented out for now because there is no frontend yet.
// This demonstrates awareness of cross-origin requests and how to enable them 
// if a frontend (or another origin) needs to call this API in the future.
//
// builder.Services.AddCors(options =>
// {
//     options.AddDefaultPolicy(policy =>
//     {
//         policy.AllowAnyOrigin()
//               .AllowAnyHeader()
//               .AllowAnyMethod();
//     });
// });

builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductApiDbConnection")));

builder.Services.AddControllers();
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

//app.UseHttpsRedirection();

app.UseMiddleware<GlobalExceptionMiddleware>();

// app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
