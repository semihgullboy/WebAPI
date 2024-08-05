using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;

    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var request = context.Request;
        var originalBodyStream = context.Response.Body;

        try
        {
            // Log the request
            _logger.LogInformation($"Request: {request.Method} {request.Path}");

            using (var newBodyStream = new MemoryStream())
            {
                context.Response.Body = newBodyStream;

                await _next(context);

                // Log the response
                newBodyStream.Seek(0, SeekOrigin.Begin);
                var responseBody = new StreamReader(newBodyStream).ReadToEnd();
                _logger.LogInformation($"Response: {context.Response.StatusCode} {responseBody}");

                newBodyStream.Seek(0, SeekOrigin.Begin);
                await newBodyStream.CopyToAsync(originalBodyStream);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while processing the request.");
            throw;
        }
    }
}
