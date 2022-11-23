using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MyRest;
using MyRest.Consumers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<RestaurantBookingRequestConsumer>()
        .Endpoint(e =>
        {
            e.Temporary = true;
        });

    x.AddConsumer<BookingRequestFaultConsumer>()
        .Endpoint(e =>
        {
            e.Temporary = true;
        });

    x.AddSagaStateMachine<RestaurantBookingSaga, RestaurantBooking>()
        .Endpoint(e => e.Temporary = true)
        .InMemoryRepository();

    x.AddDelayedMessageScheduler();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.UseDelayedMessageScheduler();
        cfg.UseInMemoryOutbox();
        cfg.ConfigureEndpoints(context);
    });

});

builder.Services.AddMassTransitHostedService();

builder.Services.AddTransient<RestaurantBooking>();
builder.Services.AddTransient<RestaurantBookingSaga>();
builder.Services.AddTransient<Restaurant>();

builder.Services.AddHostedService<Worker>();

var app = builder.Build();

app.Run();