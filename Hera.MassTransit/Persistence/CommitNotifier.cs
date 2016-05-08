using Hera.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hera.DomainModeling.DomainEvent;
using MassTransit;

namespace Hera.MassTransit.Persistence
{
    public class CommitNotifier : ICommitNotifier
    {
        private readonly IBus _bus;

        public CommitNotifier(IBus bus)
        {
            _bus = bus;
        }

        public void Notify(CommitNotificationEvent @event)
        {
            _bus.Publish(@event);
        }
    }
}
