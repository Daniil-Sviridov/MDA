using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public interface IKitchenReady
    {
        public Guid OrderId { get; }

        public bool Ready { get; }
    }
}
