using MemDB.Services;
using MemDB.Models;
using MemDB.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IRecordDB, DictionaryDB>();

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<RecordService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
app.MapGrpcReflectionService();

app.Run();
