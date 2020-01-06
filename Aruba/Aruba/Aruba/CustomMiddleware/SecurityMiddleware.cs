using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Aruba.CustomMiddleware
{
    /// <summary>
    /// From https://dotnetcoretutorials.com/2017/03/10/creating-custom-middleware-asp-net-core/
    /// </summary>
    public class SecurityMiddleware
    {
        private readonly RequestDelegate _next;

        public SecurityMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("X-Xss-Protection", "1");
            httpContext.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
            httpContext.Response.Headers.Add("X-Content-Type-Options", "nosniff");

            if (httpContext.Request.Path.StartsWithSegments("/Green"))
            {
                return httpContext.Response.WriteAsync("Welcome to Greenland; you were intercepted by custom security middleware which redirected you to Greenland");
            }

            return _next(httpContext);
        }
    }

    public static class SecurityMiddlewareExtensions
    {
        public static IApplicationBuilder UseSecurityMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SecurityMiddleware>();
        }
    }

}