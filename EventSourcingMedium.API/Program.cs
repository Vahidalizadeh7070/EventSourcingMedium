using EventSourcingMedium.API.Models;
using EventSourcingMedium.API.Services.PostInformationServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Register AppDbContext
var connectionString = builder.Configuration.GetConnectionString("DbConnection");

builder.Services.AddDbContextPool<AppDbContext>(db => db.UseSqlServer(connectionString));

// Register post information service
builder.Services.AddScoped<IPostInformationService, PostInformationService>();

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
