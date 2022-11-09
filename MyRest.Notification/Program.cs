
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MyRest.Notification;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<Worker>();

var app = builder.Build();

app.Run();