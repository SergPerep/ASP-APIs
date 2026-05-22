using Shared;
using Foods;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddModule<FoodsModule>();

var app = builder.Build();

app.MapGet("/", () => "Minimal API with modules");

app.MapModules();

app.Run();
