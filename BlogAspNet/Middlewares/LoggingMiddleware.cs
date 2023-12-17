using BlogAspNet.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BlogAspNet.Middlewares
{

    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context, IRequestRepository repository)
        {
            LogConsole(context);
            await LogFile(context);
            await LogRequest(context, repository);
            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
        private void LogConsole(HttpContext context)
        {
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
        }
        private async Task LogFile(HttpContext context)
        {
            string logMessage = $"\n[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}";
            // Для логирования данных о запросе используем свойста объекта HttpContext
            string logPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", "RequestLog.txt");

            await File.AppendAllTextAsync(logPath, logMessage);
        }
        private async Task LogRequest(HttpContext context, IRequestRepository repository)
        {
            Request newRequest = new Request()
            {
                Url = $"http://{context.Request.Host.Value + context.Request.Path}"
            };
            await repository.AddRequest(newRequest);

        }
    }
}
