using GreenPipes;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyRest.Notification;
using MyRest.Notification.Consumers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<NotifierTableBookedConsumer>();
    x.AddConsumer<KitchenReadyConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.UseMessageRetry(r =>
        {
            r.Exponential(5,
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(100),
                TimeSpan.FromSeconds(5));
            r.Ignore<StackOverflowException>();
            r.Ignore<ArgumentNullException>(x => x.Message.Contains("Consumer"));
        });
        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddSingleton<Notifier>();
builder.Services.AddMassTransitHostedService(true);

var app = builder.Build();

app.Run();