using Microsoft.AspNetCore.Http;
using Shop.Core.Entities;
using Shop.Core.Interfaces.Services;
using Shop.Infrastructure.Helpers;
using System.IO;
using System.Threading.Tasks;

namespace Shop.Api.Middlewares
{
    public class RequestHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public RequestHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, ILogService logService)
        {
            if (!context.Request.Path.ToString().StartsWith("/api"))
            {
                await next(context);

                return;
            }

            var log = new Log
            {
                Header = context.Request.Headers.ToString(),
                Method = context.Request.Method,
                Path = context.Request.Path,
                QueryString = context.Request.QueryString.Value,
                Host = context.Request.Host.Host,
                ClientIp = context.Connection.RemoteIpAddress.ToString(),
                TransactionDate = DateUtils.GetCurrentDate()
            };

            context.Request.EnableBuffering();

            var body = await new StreamReader(context.Request.Body).ReadToEndAsync();

            log.RequestBody = body.ToString();
            context.Request.Body.Position = 0;

            await next(context);

            log.StatusCode = context.Response.StatusCode;

            await logService.SaveAsync(log);
        }
    }
}