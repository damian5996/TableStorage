using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cqrs
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostingEnvironment _env;

        public ErrorHandlingMiddleware(RequestDelegate next, IHostingEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Unhandled exception");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var apiReg = new Regex(@"^/api");

            if (apiReg.IsMatch(context.Request.Path))
            {
                return PrepareResponse(context, exception, HttpStatusCode.InternalServerError);
            }

            context.Response.Redirect("/");
            return context.Response.WriteAsync("Przekierowywanie...");
        }

        private Task PrepareResponse(HttpContext context, Exception exception, HttpStatusCode code)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            var result = context.Response.WriteJsonAsync(new
            {
                Code = context.Response.StatusCode.ToString(),
                Message = "Wystąpił nieoczekiwany błąd.",
                Details = _env.IsProduction() ? null : exception.Message,
            });
            return result;
        }
    }

    internal static class HttpExtensions
    {
        private static readonly Newtonsoft.Json.JsonSerializer Serializer = new Newtonsoft.Json.JsonSerializer
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        public static async Task WriteJsonAsync<T>(this HttpResponse response, T obj)
        {
            using (var writer = new HttpResponseStreamWriter(response.Body, Encoding.UTF8))
            {
                using (var jsonWriter = new JsonTextWriter(writer))
                {
                    jsonWriter.CloseOutput = false;
                    jsonWriter.AutoCompleteOnClose = false;

                    Serializer.Serialize(jsonWriter, obj);
                }
            }
        }
    }
}
