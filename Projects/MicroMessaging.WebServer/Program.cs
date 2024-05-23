using MicroMessaging.WebServer.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.AddApplicationBuilders();
builder.Services.AddApplicationServices(builder);

var app = builder.Build();

app.AddWebApplicationComponents();

app.Run();
