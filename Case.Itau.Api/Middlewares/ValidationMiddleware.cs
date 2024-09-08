using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Case.Itau.Api.Middlewares
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;

            using (var newBodyStream = new MemoryStream())
            {
                context.Response.Body = newBodyStream;

                await _next(context);

                // Se o status for 400 e o conteúdo não for preenchido
                if (context.Response.StatusCode == StatusCodes.Status400BadRequest && newBodyStream.Length == 0)
                {
                    context.Response.ContentType = "application/json";
                    var errorResponse = new
                    {
                        StatusCode = 400,
                        Message = "Erro na desserialização do JSON ou dados inválidos.",
                    };
                    var errorJson = JsonSerializer.Serialize(errorResponse);
                    await context.Response.WriteAsync(errorJson);
                }

                newBodyStream.Seek(0, SeekOrigin.Begin);
                await newBodyStream.CopyToAsync(originalBodyStream);
            }
        }
    }
}