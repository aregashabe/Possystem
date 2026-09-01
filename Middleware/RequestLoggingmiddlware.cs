using System.Diagnostics;
public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var correlationId =  Guid.NewGuid().ToString("N")[..8]; // Generate a short correlation ID
        context.Response.Headers["X-Correlation-ID"] = correlationId; // Add the correlation ID to the response headers
        var stopWatch = Stopwatch.StartNew();
        // Log the request details
        _logger.LogInformation("START: {method} {url} (Correlation ID: {correlationId})", context.Request.Method, context.Request.Path, correlationId);

        // Call the next middleware in the pipeline
        await _next(context);
        stopWatch.Stop();
        _logger.LogInformation("END: {method} {url} (Correlation ID: {correlationId}, Duration: {duration} ms, Status Code: {statusCode})", context.Request.Method, context.Request.Path, correlationId, stopWatch.ElapsedMilliseconds, context.Response.StatusCode);
    }
}