using System;

namespace MyRest.Messaging
{
    public interface IBookingRequest
    {
        public Guid OrderId { get; }
        
        public Guid ClientId { get; }
        
        public Dish? PreOrder { get; }
        
        public DateTime CreationDate { get; }
    }
}