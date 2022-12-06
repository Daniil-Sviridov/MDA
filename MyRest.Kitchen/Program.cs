using MassTransit;
using Microsoft.AspNetCore.Builder;
using MyRest.Kitchen.Consumers;
using Microsoft.Extensions.DependencyInjection;
using MyRest.Kitchen;

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

builder.Services.AddSingleton<Manager>();
builder.Services.Configure<MassTransitHostOptions>(options =>
{
    options.WaitUntilStarted = true;
    options.StartTimeout = TimeSpan.FromSeconds(30);
    options.StopTimeout = TimeSpan.FromMinutes(1);
});

var app = builder.Build();

app.Run();