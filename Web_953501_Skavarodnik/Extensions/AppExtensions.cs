using Microsoft.AspNetCore.Builder;
using Web_953501_Skavarodnik.Middleware;

namespace Web_953501_Skavarodnik.Extensions
{
    public static class AppExtensions
    {
        public static IApplicationBuilder UseFileLogging(this
        IApplicationBuilder app)
        => app.UseMiddleware<LogMiddleware>();
    }
}
