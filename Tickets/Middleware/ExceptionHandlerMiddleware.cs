using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core;
using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Tickets.Middleware;

public class ExceptionHandlerMiddleware : IMiddleware
{

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (TimeoutException exception)
        {
            context.Response.StatusCode = StatusCodes.Status408RequestTimeout;
        }
        catch (ValidationException exception)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
           
        }
        catch (DbUpdateException exception)
        {
            context.Response.StatusCode = StatusCodes.Status409Conflict;
           
        }
        catch (Exception exception)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
    
    
}