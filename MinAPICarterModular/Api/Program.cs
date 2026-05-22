using Shared;
using Foods;
using Carter;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddModule<FoodsModule>();
builder.Services.AddCarter();

var app = builder.Build();

// app.MapGet("/", () => "Minimal API with modules");

app.MapCarter();

app.Run();
