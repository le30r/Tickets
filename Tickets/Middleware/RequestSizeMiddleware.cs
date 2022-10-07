namespace Tickets.Middleware;

public class RequestSizeMiddleware : IMiddleware
{
    private const long MaxRequestSize = 2048L;
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.ContentLength > MaxRequestSize)
        {
            context.Response.StatusCode = StatusCodes.Status413PayloadTooLarge;
        }
        else
        {
            await next.Invoke(context);
        }
        
    }
}