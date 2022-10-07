using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json.Nodes;
using Tickets.Model.DTO;
using Tickets.Validation.JsonValidation;

namespace Tickets.Middleware;

public class JsonValidationMiddleware : IMiddleware
{
   
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var schemaName = GetSchemaName(context);

        var body = GetRequestBody(context);
        if (JsonValidator.Validate(JsonNode.Parse(body), schemaName))
        {
            await next.Invoke(context);
        }
        else
        {
            throw new ValidationException();
        }
    }

    private string? GetSchemaName(HttpContext context)
    {
        var requestPathValue = context.Request.Path.Value;
        if (requestPathValue != null && requestPathValue.EndsWith("/"))
        {
            requestPathValue = requestPathValue.Substring(0, requestPathValue.Length - 1);
        }
        return requestPathValue?.Substring(requestPathValue.LastIndexOf("/") + 1);

    }

    private string? GetRequestBody(HttpContext context)
    {
        context.Request.EnableBuffering();
        using var streamReader = new StreamReader(context.Request.Body, leaveOpen: true);
        var content = streamReader.ReadToEndAsync().Result;
        context.Request.Body.Position = 0;
        return content;
    }
}