namespace apidotnet.Middlewares;

public class TimeMiddleware(RequestDelegate nextRequest)
{
    private readonly RequestDelegate next = nextRequest;

    public async Task Invoke(HttpContext httpContext)
    {
        // The previous middleware is executed
        await next(httpContext);

        // Now we execute our logic
        if (httpContext.Request.Query.Any(p => p.Key == "time"))
        {
            await httpContext.Response.WriteAsync(DateTime.Now.ToShortTimeString());
        }
    }
}

public static class TimeMiddlewareExtension
{
    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TimeMiddleware>();
    }
}