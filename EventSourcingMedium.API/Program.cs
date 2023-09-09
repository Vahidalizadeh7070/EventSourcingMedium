using EventSourcingMedium.API.Models;
using EventSourcingMedium.API.Services.EventStreaming;
using EventSourcingMedium.API.Services.PostInformationServices.CommandService;
using EventSourcingMedium.API.Services.PostInformationServices.QueryService;
using EventStore.ClientAPI;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Register AppDbContext
var connectionString = builder.Configuration.GetConnectionString("DbConnection");

builder.Services.AddDbContextPool<AppDbContext>(db => db.UseSqlServer(connectionString));

// Register post information service
builder.Services.AddScoped<IPostInformationCommandService, PostInformationCommandService>();
builder.Services.AddScoped<IPostInformationQueryService, PostInformationQueryService>();

// Register EventStoreService
builder.Services.AddScoped<IEventStoreService, EventStoreService>();

var eventConnectionString = EventStoreConnection.Create(
    connectionString: EventStoreDB.ConnectionString,
    builder: ConnectionSettings.Create().LimitRetriesForOperationTo(10).SetReconnectionDelayTo(TimeSpan.FromMicroseconds(100)),
    connectionName: EventStoreDB.TaskName);

eventConnectionString.ConnectAsync().GetAwaiter().GetResult();
builder.Services.AddSingleton(eventConnectionString);
// Register AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Register MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
