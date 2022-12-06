namespace MyRest.Messaging;

public class BookingCancellation : IBookingCancellation
{
    public BookingCancellation(Guid orderId)
    {
        OrderId = orderId;
    }

    public Guid OrderId { get; }
}