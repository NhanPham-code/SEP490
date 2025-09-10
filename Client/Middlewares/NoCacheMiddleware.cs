using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middlewares
{
    public class NoCacheMiddleware
    {
        private readonly RequestDelegate _next;

        public NoCacheMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task InvokeAsync(HttpContext context)
        {
            // Thêm các header vào response để ngăn trình duyệt cache.
            // OnStarting đảm bảo các header này được thêm ngay trước khi response được gửi đi.
            context.Response.OnStarting(() =>
            {
                context.Response.Headers.Append("Cache-Control", "no-cache, no-store, must-revalidate");
                context.Response.Headers.Append("Pragma", "no-cache");
                context.Response.Headers.Append("Expires", "0");
                return Task.CompletedTask;
            });

            // Chuyển request cho middleware tiếp theo
            return _next(context);
        }
    }
}
