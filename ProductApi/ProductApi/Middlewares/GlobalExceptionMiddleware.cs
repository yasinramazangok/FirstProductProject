using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Http;
using System.Text.Json;

namespace ProductApi.API.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError(dbEx, "Veritabanı hatası oluştur! Path: {Path}", context.Request.Path);
                await HandleExceptionAsync(context, HttpStatusCode.BadRequest, "Veritabanı hatası oluştu!", dbEx.Message);
            }
            catch (KeyNotFoundException knfEx)
            {
                await HandleExceptionAsync(context, HttpStatusCode.NotFound, knfEx.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Beklenmeyen bir hata oluştu. Path: {Path}", context.Request.Path);
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, "Beklenmeyen bir hata oluştu!", ex.Message);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, string message, string? details = null)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var response = new
            {
                message,
                details
            };

            var json = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(json);
        }
    }
}
