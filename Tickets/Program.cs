using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tickets.Data;
using Tickets.Middleware;
using Tickets.Services;
using Tickets.Validation;

var builder = WebApplication.CreateBuilder(args);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddDbContext<TicketsContext>(o => o
    .UseNpgsql(builder
        .Configuration
        .GetConnectionString("Default"))
    .UseSnakeCaseNamingConvention());

builder.Services.AddTransient<ExceptionHandlerMiddleware>();
builder.Services.AddTransient<JsonValidationMiddleware>();
builder.Services.AddTransient<RequestSizeMiddleware>();
builder.Services.AddSingleton<EntityValidator>();
builder.Services.AddScoped<SegmentRepository>();
builder.Services.AddScoped<ITicketService, TicketService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiVersioning(options => options.DefaultApiVersion = new ApiVersion(1, 0));
var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseMiddleware<RequestSizeMiddleware>();
app.UseMiddleware<JsonValidationMiddleware>();
app.MapControllers();

app.Run();