using System;

namespace MyRest.Messaging;

public interface IBookingCancellation
{
    public Guid OrderId { get; }
}
