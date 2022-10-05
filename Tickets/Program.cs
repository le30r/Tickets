using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tickets.Model;
    
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TicketsContext>(o => o
    .UseNpgsql(builder
        .Configuration
        .GetConnectionString("Default"))
    .UseSnakeCaseNamingConvention());


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiVersioning(options => options.DefaultApiVersion = new ApiVersion(1, 0));
builder.Services.Configure<FormOptions>(options => options.MultipartBodyLengthLimit = 2048);

var app = builder.Build();





app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();