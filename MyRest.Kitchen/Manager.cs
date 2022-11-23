using MassTransit;
using MyRest.Messaging;

namespace MyRest.Kitchen
{
    internal class Manager
    {
        private readonly IBus _bus;

        public Manager(IBus bus)
        {
            _bus = bus;
        }

        public bool CheckKitchenReady(Guid orderId, Dish? dish)
        {
            return true;
        }

        internal void CheckKitchenReady(Guid orderId, object preOrder)
        {
            throw new NotImplementedException();
        }
    }
}
