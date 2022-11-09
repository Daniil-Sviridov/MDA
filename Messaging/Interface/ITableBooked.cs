﻿using System;

namespace Messaging
{
    public interface ITableBooked
    {
        public Guid OrderId { get; }

        public Guid ClientId { get; }

        public Dish? PreOrder { get; }

        public bool Success { get; }
    }
}
