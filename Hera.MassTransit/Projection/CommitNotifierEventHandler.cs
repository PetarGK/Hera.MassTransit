using Hera.Persistence;
using Hera.Projection;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.MassTransit.Projection
{
    public class CommitNotifierEventHandler : IConsumer<CommitNotificationEvent>
    {
        private readonly IPollingClient _pollingClient;

        public CommitNotifierEventHandler(IPollingClient pollingClient)
        {
            _pollingClient = pollingClient;
        }

        public async Task Consume(ConsumeContext<CommitNotificationEvent> context)
        {
            await Task.Run(() => {
                _pollingClient.Poll(context.Message);
            });
        }
    }
}
