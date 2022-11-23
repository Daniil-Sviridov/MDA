using MassTransit;
using Microsoft.AspNetCore.Builder;
using MyRest.Kitchen.Consumers;
using MyRest.Notification;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<KitchenBookingRequestedConsumer>(
        configurator =>
        {

        })
        .Endpoint(e =>
        {
            e.Temporary = true;
        }); ;

    x.AddConsumer<KitchenBookingRequestFaultConsumer>()
        .Endpoint(e =>
        {
            e.Temporary = true;
        });
    x.AddDelayedMessageScheduler();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.UseDelayedMessageScheduler();
        cfg.UseInMemoryOutbox();
        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddSingleton<Notifier>();
//builder.Services.AddMassTransitHostedService(true);

var app = builder.Build();

app.Run();